package ro.ubbcluj.mpp.domain;

import java.time.LocalDateTime;

public class Reservation extends Entity<Long> {
    private String clientName;
    private Long phoneNumber;
    private int numberOfTickets;
    private Long agencyUserId;
    private Long tripId;

    public Reservation(String clientName, Long phoneNumber, int numberOfTickets, Long agencyUserId, Long tripId) {
        this.clientName = clientName;
        this.phoneNumber = phoneNumber;
        this.numberOfTickets = numberOfTickets;
        this.agencyUserId = agencyUserId;
        this.tripId = tripId;
    }

    public String getClientName() {
        return clientName;
    }

    public void setClientName(String clientName) {
        this.clientName = clientName;
    }

    public Long getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(Long phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public int getNumberOfTickets() {
        return numberOfTickets;
    }

    public void setNumberOfTickets(int numberOfTickets) {
        this.numberOfTickets = numberOfTickets;
    }

    public Long getAgencyUserId() {
        return agencyUserId;
    }

    public void setAgencyUserId(Long agencyUserId) {
        this.agencyUserId = agencyUserId;
    }

    public Long getTripId() {
        return tripId;
    }

    public void setTripId(Long tripId) {
        this.tripId = tripId;
    }

    @Override
    public String toString() {
        return "Reservation{" +
                "clientName='" + clientName + '\'' +
                ", phoneNumber=" + phoneNumber +
                ", numberOfTickets=" + numberOfTickets +
                ", agencyUserId=" + agencyUserId +
                ", tripId=" + tripId +
                ", id=" + id +
                '}';
    }
}
