package travelAgency.model;

public class Reservation extends Identifiable<Long> {
    private String clientName;
    private Long phoneNumber;
    private int numberOfTickets;
    private User agencyUser;
    private Trip trip;

    public Reservation(String clientName, Long phoneNumber, int numberOfTickets, User agencyUser, Trip trip) {
        this.clientName = clientName;
        this.phoneNumber = phoneNumber;
        this.numberOfTickets = numberOfTickets;
        this.agencyUser = agencyUser;
        this.trip = trip;
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

    public Trip getTrip() {
        return trip;
    }

    public void setTrip(Trip trip) {
        this.trip = trip;
    }

    public User getAgencyUser() {
        return agencyUser;
    }

    public void setAgencyUser(User agencyUser) {
        this.agencyUser = agencyUser;
    }

    @Override
    public String toString() {
        return "Reservation{" +
                "clientName='" + clientName + '\'' +
                ", phoneNumber=" + phoneNumber +
                ", numberOfTickets=" + numberOfTickets +
                ", agencyUserUsername=" + agencyUser.getUsername() +
                ", tripLandmark=" + trip.getLandmark() +
                ", id=" + id +
                '}';
    }
}
