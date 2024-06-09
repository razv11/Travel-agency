package travelAgency.network.jsonprotocol.ams;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import servicesAMS.ITravelAgencyServicesAMS;
import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.network.dto.FilterDTO;
import travelAgency.network.jsonprotocol.*;
import travelAgency.services.TravelAgencyException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class TravelAgencyServerAMSRpcReflectionWorker implements Runnable {
    private ITravelAgencyServicesAMS server;
    private Socket connection;
    private BufferedReader input;
    private PrintWriter output;
    private Gson gsonFormatter;
    private volatile boolean connected;
    private static final Response okResponse = JsonProtocolUtils.createOkResponse();

    public TravelAgencyServerAMSRpcReflectionWorker(ITravelAgencyServicesAMS server, Socket connection) {
        this.server = server;
        this.connection = connection;
        gsonFormatter = new GsonBuilder()
                .registerTypeAdapter(LocalDateTime.class, new TravelAgencyServerAMSRpcReflectionWorker.LocalDateTimeTypeAdapter())
                .create();

        try {
            output = new PrintWriter(connection.getOutputStream());
            input = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            connected = true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private Response handleRequest(Request request) {
        Response response = null;

        if(request.getType() == RequestType.LOGIN) {
            System.out.println("Login request...");

            User user = request.getUser();
            try {
                server.login(user);
                return okResponse;
            } catch (TravelAgencyException e) {
                connected = false;
                return JsonProtocolUtils.createErrorResponse(e.getMessage());
            }
        }

        if(request.getType() == RequestType.LOGOUT) {
            System.out.println("Logout request...");

            User user = request.getUser();
            try {
                server.logout(user);
                connected = false;
                return okResponse;
            } catch (TravelAgencyException e) {
                return JsonProtocolUtils.createErrorResponse(e.getMessage());
            }
        }

        if(request.getType() == RequestType.GET_ALL_TRIPS) {
            System.out.println("Get all trips request...");

            try {
                Trip[] trips = server.getTrips();
                return JsonProtocolUtils.createGetAllTripsResponse(trips);

            } catch (TravelAgencyException e) {
                return JsonProtocolUtils.createErrorResponse(e.getMessage());
            }
        }

        if(request.getType() == RequestType.GET_SEARCHED_TRIPS) {
            System.out.println("Get searched trips request...");

            try {
                FilterDTO filter = request.getFilter();
                Trip[] searchedTrips = server.getSearchedTrips(filter.getLandmark(), filter.getStartHour(), filter.getEndHour());

                return JsonProtocolUtils.createGetSearchedTripsResponse(searchedTrips);
            } catch (TravelAgencyException e) {
                return JsonProtocolUtils.createErrorResponse(e.getMessage());
            }
        }

        if(request.getType() == RequestType.RESERVE_TRIP) {
            System.out.println("Reserve trip request...");

            Reservation reservation = request.getReservation();

            try {
                server.reserveTrip(reservation);
                return okResponse;

            } catch (TravelAgencyException e) {
                return JsonProtocolUtils.createErrorResponse(e.getMessage());
            }
        }

        return response;
    }

    private void sendResponse(Response response) throws IOException {
        String responseLine = gsonFormatter.toJson(response);
        System.out.println("Sending response..." + responseLine);

        synchronized (output) {
            output.println(responseLine);
            output.flush();
        }
    }

    @Override
    public void run() {
        while (connected) {
            try {
                String requestLine = input.readLine();
                Request request = gsonFormatter.fromJson(requestLine, Request.class);
                Response response = handleRequest(request);

                if(response != null) {
                    sendResponse(response);
                }
            } catch (IOException e) {
                e.printStackTrace();
            }

            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        try {
            input.close();
            output.close();
            connection.close();
        } catch (IOException e) {
            System.out.println("Error while trying to close input/output/connection in JsonWorker");
        }
    }

    public void tripReserved(Reservation reservation) throws TravelAgencyException {
        Response response = JsonProtocolUtils.createTripReservedResponse(reservation);
        System.out.println("Trip reserved...");

        try {
            sendResponse(response);
        } catch (IOException e) {
            e.printStackTrace();
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
