package travelAgency.network.jsonprotocol;

import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.network.dto.FilterDTO;

import java.io.Serializable;
import java.util.Arrays;

public class Request implements Serializable {
    private User user;
    private Trip[] trip;
    private Reservation reservation;
    private RequestType type;
    private FilterDTO filter;

    public Request() { }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Trip[] getTrip() {
        return trip;
    }

    public void setTrip(Trip[] trip) {
        this.trip = trip;
    }

    public Reservation getReservation() {
        return reservation;
    }

    public void setReservation(Reservation reservation) {
        this.reservation = reservation;
    }

    public RequestType getType() {
        return type;
    }

    public void setType(RequestType type) {
        this.type = type;
    }

    public FilterDTO getFilter() {
        return filter;
    }

    public void setFilter(FilterDTO filter) {
        this.filter = filter;
    }

    @Override
    public String toString() {
        return "Request{" +
                "user=" + user +
                ", trip=" + Arrays.toString(trip) +
                ", reservation=" + reservation +
                ", type=" + type +
                '}';
    }
}
