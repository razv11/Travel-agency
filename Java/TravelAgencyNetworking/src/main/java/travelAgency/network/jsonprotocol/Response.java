package travelAgency.network.jsonprotocol;

import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;

import java.io.Serializable;
import java.util.Arrays;

public class Response implements Serializable {
    private User user;
    private Trip[] trips;
    private Trip[] searchedTrips;
    private Reservation reservation;
    private ResponseType type;
    private String errorMessage;

    public Response() { }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Trip[] getTrips() {
        return trips;
    }

    public void setTrips(Trip[] trips) {
        this.trips = trips;
    }

    public Reservation getReservation() {
        return reservation;
    }

    public void setReservation(Reservation reservation) {
        this.reservation = reservation;
    }

    public ResponseType getType() {
        return type;
    }

    public void setType(ResponseType type) {
        this.type = type;
    }

    public String getErrorMessage() {
        return errorMessage;
    }

    public void setErrorMessage(String errorMessage) {
        this.errorMessage = errorMessage;
    }

    public Trip[] getSearchedTrips() {
        return searchedTrips;
    }

    public void setSearchedTrips(Trip[] searchedTrips) {
        this.searchedTrips = searchedTrips;
    }

    @Override
    public String toString() {
        return "Response{" +
                "user=" + user +
                ", trips=" + Arrays.toString(trips) +
                ", reservation=" + reservation +
                ", type=" + type +
                ", errorMessage='" + errorMessage + '\'' +
                '}';
    }
}
