package travelAgency.network.jsonprotocol;

import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.network.dto.FilterDTO;

public class JsonProtocolUtils {

    public static Request createLoginRequest(User user) {
        Request request = new Request();
        request.setType(RequestType.LOGIN);
        request.setUser(user);
        return request;
    }

    public static Request createGetAllTripsRequest() {
        Request request = new Request();
        request.setType(RequestType.GET_ALL_TRIPS);
        return request;
    }

    public static Request createReserveTripRequest(Reservation reservation) {
        Request request = new Request();
        request.setType(RequestType.RESERVE_TRIP);
        request.setReservation(reservation);
        return request;
    }

    public static Request createGetSearchedTripsRequest(FilterDTO filterDTO) {
        Request request = new Request();
        request.setType(RequestType.GET_SEARCHED_TRIPS);
        request.setFilter(filterDTO);
        return request;
    }

    public static Request createLogoutRequest(User user) {
        Request request = new Request();
        request.setType(RequestType.LOGOUT);
        request.setUser(user);
        return request;
    }

    public static Response createOkResponse() {
        Response response = new Response();
        response.setType(ResponseType.OK);
        return response;
    }

    public static Response createErrorResponse(String errorMessage) {
        Response response = new Response();
        response.setType(ResponseType.ERROR);
        response.setErrorMessage(errorMessage);
        return response;
    }

    public static Response createGetAllTripsResponse(Trip[] trips) {
        Response response = new Response();
        response.setType(ResponseType.GET_ALL_TRIPS);
        response.setTrips(trips);
        return response;
    }

    public static Response createGetSearchedTripsResponse(Trip[] searchedTrips) {
        Response response = new Response();
        response.setType(ResponseType.GET_SEARCHED_TRIPS);
        response.setSearchedTrips(searchedTrips);
        return response;
    }

    public static Response createTripReservedResponse(Reservation reservation) {
        Response response = new Response();
        response.setType(ResponseType.TRIP_RESERVED);
        response.setReservation(reservation);
        return response;
    }
}
