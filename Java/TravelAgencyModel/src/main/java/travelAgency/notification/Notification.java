package travelAgency.notification;

import travelAgency.model.Reservation;

public class Notification {
    private NotificationType type;
    private Long tripId;
    private Integer nuberOfTickets;


    public Notification() {

    }
    public Notification(NotificationType type) {
        this.type = type;
    }

    public Notification(NotificationType type, Long tripId, Integer nuberOfTickets) {
        this.type = type;
        this.tripId = tripId;
        this.nuberOfTickets = nuberOfTickets;
    }

    public NotificationType getType() {
        return type;
    }

    public void setType(NotificationType type) {
        this.type = type;
    }

    public Long getTripId() {
        return tripId;
    }

    public void setTripId(Long tripId) {
        this.tripId = tripId;
    }

    public Integer getNuberOfTickets() {
        return nuberOfTickets;
    }

    public void setNuberOfTickets(Integer nuberOfTickets) {
        this.nuberOfTickets = nuberOfTickets;
    }
}
