package travelAgency.model;

import java.time.LocalDateTime;

public class Trip extends Identifiable<Long> {
    private String landmark;
    private String transportCompanyName;
    private LocalDateTime departureTime;
    private Float price;
    private int availableSeats;

    public Trip() { }

    public Trip(String landmark, String transportCompanyName, LocalDateTime departureTime, Float price, int availableSeats) {
        this.landmark = landmark;
        this.transportCompanyName = transportCompanyName;
        this.departureTime = departureTime;
        this.price = price;
        this.availableSeats = availableSeats;
    }

    public String getLandmark() {
        return landmark;
    }

    public void setLandmark(String landmark) {
        this.landmark = landmark;
    }

    public String getTransportCompanyName() {
        return transportCompanyName;
    }

    public void setTransportCompanyName(String transportCompanyName) {
        this.transportCompanyName = transportCompanyName;
    }

    public LocalDateTime getDepartureTime() {
        return departureTime;
    }

    public void setDepartureTime(LocalDateTime departureTime) {
        this.departureTime = departureTime;
    }

    public Float getPrice() {
        return price;
    }

    public void setPrice(Float price) {
        this.price = price;
    }

    public int getAvailableSeats() {
        return availableSeats;
    }

    public void setAvailableSeats(int availableSeats) {
        this.availableSeats = availableSeats;
    }

    @Override
    public String toString() {
        return "Trip{" +
                "landmark='" + landmark + '\'' +
                ", transportCompanyName='" + transportCompanyName + '\'' +
                ", departureTime=" + departureTime +
                ", price=" + price +
                ", availableSeats=" + availableSeats +
                ", id=" + id +
                '}';
    }
}
