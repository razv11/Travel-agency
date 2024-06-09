package travelAgency.network.protobuffprotocol;

import com.google.protobuf.ByteString;
import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.services.TravelAgencyException;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class ProtoUtils {
    public static String getError(TravelAgencyProtobufs.Response response) {
        return response.getErrorMessage();
    }

    public static User getUser(TravelAgencyProtobufs.Request request) {
        User user = new User(null, null);
        user.setId(request.getUser().getId());
        user.setUsername(request.getUser().getUsername());
        user.setPassword(request.getUser().getPassword());
        return user;
    }

    public static Reservation getReservation(TravelAgencyProtobufs.Request request) {

        System.out.println(request);
        String clientName = request.getReservation().getClientName();
        String phoneNumber = request.getReservation().getPhoneNumber();

        int nTickets = request.getReservation().getNumberOfTickets();
        User user = new User(null, null);
        user.setId(request.getReservation().getUser().getId());
        user.setUsername(request.getReservation().getUser().getUsername());
        user.setPassword(request.getReservation().getUser().getPassword());

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm");
        Trip trip = new Trip(null, null, null, null, -1);
        trip.setId(request.getReservation().getTrip().getId());
        trip.setLandmark(request.getReservation().getTrip().getLandmark());
        trip.setPrice(request.getReservation().getTrip().getPrice());
        trip.setAvailableSeats(request.getReservation().getTrip().getAvailableSeats());
        trip.setTransportCompanyName(request.getReservation().getTrip().getTransportCompanyName());
        //trip.setDepartureTime(LocalDateTime.parse(request.getReservation().getTrip().getDepartureTime(), formatter));

        return new Reservation(clientName, Long.parseLong(phoneNumber), nTickets, user, trip);
    }

    public static TravelAgencyProtobufs.Response createOkResponse() {
        TravelAgencyProtobufs.Response response = TravelAgencyProtobufs.Response.newBuilder().setType(TravelAgencyProtobufs.Response.ResponseType.Ok).build();
        return response;
    }

    public static TravelAgencyProtobufs.Response createErrorResponse(String error) {
        TravelAgencyProtobufs.Response response = TravelAgencyProtobufs.Response.newBuilder().setType(TravelAgencyProtobufs.Response.ResponseType.Error).setErrorMessage(error).build();
        return response;
    }

    public static TravelAgencyProtobufs.Response createGetAllTripsResponse(Trip[] trips) {
        TravelAgencyProtobufs.Response.Builder response = TravelAgencyProtobufs.Response.newBuilder().setType(TravelAgencyProtobufs.Response.ResponseType.GetAllTrips);
        for(Trip trip : trips) {
            TravelAgencyProtobufs.Trip tripDTO = TravelAgencyProtobufs.Trip.newBuilder()
                    .setId(trip.getId())
                    .setLandmark(trip.getLandmark())
                    .setAvailableSeats(trip.getAvailableSeats())
                    .setDepartureTime(trip.getDepartureTime().toString())
                    .setTransportCompanyName(trip.getTransportCompanyName())
                    .setPrice(trip.getPrice())
                    .setDepartureTime(trip.getDepartureTime().toString())
                    .build();

            response.addTrips(tripDTO);
        }

        return response.build();
    }

    public static TravelAgencyProtobufs.Response createGetSearchedTripsResponse(Trip[] trips) {
        TravelAgencyProtobufs.Response.Builder response = TravelAgencyProtobufs.Response.newBuilder().setType(TravelAgencyProtobufs.Response.ResponseType.GetSearchedTrips);
        for(Trip trip : trips) {
            TravelAgencyProtobufs.Trip tripDTO = TravelAgencyProtobufs.Trip.newBuilder()
                    .setId(trip.getId())
                    .setLandmark(trip.getLandmark())
                    .setAvailableSeats(trip.getAvailableSeats())
                    .setDepartureTime(trip.getDepartureTime().toString())
                    .setTransportCompanyName(trip.getTransportCompanyName())
                    .setPrice(trip.getPrice())
                    //.setDepartureTime(trip.getDepartureTime().toString())
                    .build();

            response.addTrips(tripDTO);
        }

        return response.build();
    }

    public static TravelAgencyProtobufs.Response createTripReservedResponse(Reservation reservation) {
        TravelAgencyProtobufs.User user = TravelAgencyProtobufs.User.newBuilder()
                .setId(reservation.getAgencyUser().getId())
                .setUsername(reservation.getAgencyUser().getUsername())
                .setPassword(reservation.getAgencyUser().getPassword())
                .build();

        TravelAgencyProtobufs.Trip trip = TravelAgencyProtobufs.Trip.newBuilder()
                .setId(reservation.getTrip().getId())
                .setLandmark(reservation.getTrip().getLandmark())
                .setTransportCompanyName(reservation.getTrip().getTransportCompanyName())
                .setPrice(reservation.getTrip().getPrice())
                //.setDepartureTime(reservation.getTrip().getDepartureTime().toString())
                .setAvailableSeats(reservation.getTrip().getAvailableSeats())
                .build();


        TravelAgencyProtobufs.Reservation newReservation = TravelAgencyProtobufs.Reservation.newBuilder()
                .setClientName(reservation.getClientName())
                .setNumberOfTickets(reservation.getNumberOfTickets())
                .setUser(user)
                .setTrip(trip)
                .build();

        TravelAgencyProtobufs.Response response = TravelAgencyProtobufs.Response.newBuilder()
                .setType(TravelAgencyProtobufs.Response.ResponseType.TripReserved)
                .setReservation(newReservation)
                .build();

        return response;
    }
}
