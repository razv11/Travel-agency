package travelAgency.network.protobuffprotocol;

import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.model.Reservation;
import travelAgency.services.ITravelAgencyObserver;
import travelAgency.services.ITravelAgencyServices;
import travelAgency.services.TravelAgencyException;

import java.io.*;
import java.net.Socket;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class ProtoAgencyTravelWorker implements Runnable, ITravelAgencyObserver {
    private ITravelAgencyServices server;
    private Socket connection;
    private InputStream input;
    private OutputStream output;
    private volatile boolean connected;

    public ProtoAgencyTravelWorker(ITravelAgencyServices server, Socket connection) {
        this.server = server;
        this.connection = connection;
        try {
            output = connection.getOutputStream();
            input = connection.getInputStream();
            connected = true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private TravelAgencyProtobufs.Response handleRequest(TravelAgencyProtobufs.Request request) {
        TravelAgencyProtobufs.Response response = null;

        switch (request.getType()) {
            case Login: {
                System.out.println("Login request...");
                User user = ProtoUtils.getUser(request);
                try {
                    server.login(user, this);
                    return ProtoUtils.createOkResponse();
                } catch (TravelAgencyException e) {
                    connected = false;
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }

            case Logout: {
                System.out.println("Logout request...");
                User user = ProtoUtils.getUser(request);
                try {
                    server.logout(user, this);
                    connected = false;
                    return ProtoUtils.createOkResponse();
                } catch (TravelAgencyException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }

            case GetAllTrips: {
                System.out.println("Get all trips request...");
                try {
                    Trip[] trips = server.getTrips();
                    return ProtoUtils.createGetAllTripsResponse(trips);

                } catch (TravelAgencyException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }

            case GetSearchedTrips: {
                System.out.println("Get searched trips request...");
                try {
                    Trip[] trips = server.getSearchedTrips(request.getLandmark(), request.getStartHour(), request.getEndHour());
                    return ProtoUtils.createGetSearchedTripsResponse(trips);

                } catch (TravelAgencyException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }

            case ReserveTrip: {
                System.out.println("Reserve trip request...");

                Reservation reservation = ProtoUtils.getReservation(request);

                try {
                    server.reserveTrip(reservation);
                    return ProtoUtils.createOkResponse();

                } catch (TravelAgencyException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
        }

        return response;
    }

    private void sendResponse(TravelAgencyProtobufs.Response response) throws IOException {
        System.out.println("Sending response..." + response);
        response.writeDelimitedTo(output);
        output.flush();
    }

    @Override
    public void run() {
        while (connected) {
            try {
                System.out.println("Waiting requests...");
                TravelAgencyProtobufs.Request request = TravelAgencyProtobufs.Request.parseDelimitedFrom(input);
                System.out.println("Request received: " + request);

                TravelAgencyProtobufs.Response response = handleRequest(request);

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

    @Override
    public void tripReserved(Reservation reservation) throws TravelAgencyException {
        System.out.println("Trip reserved...");

        try {
            sendResponse(ProtoUtils.createTripReservedResponse(reservation));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


//    private class LocalDateTimeTypeAdapter extends TypeAdapter<LocalDateTime> {
//        private final DateTimeFormatter formatter = DateTimeFormatter.ISO_LOCAL_DATE_TIME;
//
//        @Override
//        public void write(JsonWriter out, LocalDateTime value) throws IOException {
//            if (value == null) {
//                out.nullValue();
//            } else {
//                out.value(formatter.format(value));
//            }
//        }
//
//        @Override
//        public LocalDateTime read(JsonReader in) throws IOException {
//            if (in.hasNext()) {
//                String value = in.nextString();
//                return LocalDateTime.parse(value, formatter);
//            }
//            return null;
//        }
//    }

}
