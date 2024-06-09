package travelAgency.network.jsonprotocol;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.network.dto.FilterDTO;
import travelAgency.services.ITravelAgencyObserver;
import travelAgency.services.ITravelAgencyServices;
import travelAgency.services.TravelAgencyException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class TravelAgencyServicesJsonProxy implements ITravelAgencyServices {
    private String host;
    private int port;
    private ITravelAgencyObserver client;
    private BufferedReader input;
    private PrintWriter output;
    private Gson gsonFormatter;
    private Socket connection;

    private BlockingQueue<Response> responses;
    private volatile boolean finished;

    public TravelAgencyServicesJsonProxy(String host, int port) {
        this.host = host;
        this.port = port;
        responses = new LinkedBlockingQueue<>();
    }

    private void initializeConnection() throws TravelAgencyException {
        try {
            gsonFormatter = new GsonBuilder()
                    .registerTypeAdapter(LocalDateTime.class, new TravelAgencyServicesJsonProxy.LocalDateTimeTypeAdapter())
                    .create();
            connection = new Socket(host, port);
            output = new PrintWriter(connection.getOutputStream());
            output.flush();
            input = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            finished = false;
            startReader();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void startReader() {
        Thread newThread = new Thread(new ReaderThread());
        newThread.start();
    }

    private void sendRequest(Request request) throws TravelAgencyException {
        String requestLine = gsonFormatter.toJson(request);
        try {
            output.println(requestLine);
            output.flush();
        } catch (Exception e) {
            throw new TravelAgencyException("Error while trying to send object " + e);
        }
    }

    private Response readResponse() throws TravelAgencyException {
        Response response = null;
        try {
            response = responses.take();
        } catch (Exception e) {
            throw new TravelAgencyException("Error while trying to read response " + e);
        }

        return response;
    }

    private void closeConnection() {
        finished = true;
        try {
            input.close();
            output.close();
            connection.close();
            client = null;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void login(User user, ITravelAgencyObserver client) throws TravelAgencyException {
        initializeConnection();

        Request request = JsonProtocolUtils.createLoginRequest(user);
        sendRequest(request);
        Response response = readResponse();

        if(response.getType() == ResponseType.OK) {
            this.client = client;
            return;
        }

        if(response.getType() == ResponseType.ERROR) {
            String errorMessage = response.getErrorMessage();
            closeConnection();
            throw new TravelAgencyException(errorMessage);
        }
    }

    @Override
    public void reserveTrip(Reservation reservation) throws TravelAgencyException {
        Request request = JsonProtocolUtils.createReserveTripRequest(reservation);
        sendRequest(request);
        Response response = readResponse();
        if (response.getType() == ResponseType.ERROR) {
            String errorMessage = response.getErrorMessage();
            throw new TravelAgencyException(errorMessage);
        }
    }

    @Override
    public void logout(User user, ITravelAgencyObserver client) throws TravelAgencyException {
        Request request = JsonProtocolUtils.createLogoutRequest(user);
        sendRequest(request);
        Response response = readResponse();
        closeConnection();
        if(response.getType() == ResponseType.ERROR) {
            String errorMessage = response.getErrorMessage();
            throw new TravelAgencyException(errorMessage);
        }
    }

    @Override
    public Trip[] getTrips() throws TravelAgencyException {
        Request request = JsonProtocolUtils.createGetAllTripsRequest();
        sendRequest(request);
        Response response = readResponse();

        if(response.getType() == ResponseType.ERROR) {
            String errorMessage = response.getErrorMessage();
            throw new TravelAgencyException(errorMessage);
        }

        return response.getTrips();
    }

    @Override
    public Trip[] getSearchedTrips(String landmark, int startHour, int endHour) throws TravelAgencyException {
        FilterDTO filter = new FilterDTO(landmark, startHour, endHour);

        Request request = JsonProtocolUtils.createGetSearchedTripsRequest(filter);
        sendRequest(request);
        Response response = readResponse();

        if (response.getType() == ResponseType.ERROR) {
            String errorMessage = response.getErrorMessage();
            throw new TravelAgencyException(errorMessage);
        }

        return response.getSearchedTrips();
    }

    private void handleUpdate(Response response) {
        if (response.getType() == ResponseType.TRIP_RESERVED) {
            Reservation reservation = response.getReservation();
            System.out.println("Trip reserved " + reservation);

            try {
                client.tripReserved(reservation);
            } catch (TravelAgencyException e) {
                e.printStackTrace();
            }
        }
    }

    private boolean isUpdate(Response response) {
        return response.getType() == ResponseType.TRIP_RESERVED;
    }

    private class ReaderThread implements Runnable {
        @Override
        public void run() {
            while(!finished) {
                try {
                    String responseLine = input.readLine();
                    System.out.println("Response received " + responseLine);
                    Response response = gsonFormatter.fromJson(responseLine, Response.class);
                    if(response != null) {
                        if(isUpdate(response)) {
                            handleUpdate(response);
                        } else {
                            try {
                                responses.put(response);
                            } catch (InterruptedException e) {
                                e.printStackTrace();
                            }
                        }
                    }

                } catch (IOException e) {
                    System.out.println("Error when trying to read " + e);
                }
            }
        }
    }


    private class LocalDateTimeTypeAdapter extends TypeAdapter<LocalDateTime> {
        private final DateTimeFormatter formatter = DateTimeFormatter.ISO_LOCAL_DATE_TIME;

        @Override
        public void write(JsonWriter out, LocalDateTime value) throws IOException {
            if (value == null) {
                out.nullValue();
            } else {
                out.value(formatter.format(value));
            }
        }

        @Override
        public LocalDateTime read(JsonReader in) throws IOException {
            if (in.hasNext()) {
                String value = in.nextString();
                return LocalDateTime.parse(value, formatter);
            }
            return null;
        }
    }
}
