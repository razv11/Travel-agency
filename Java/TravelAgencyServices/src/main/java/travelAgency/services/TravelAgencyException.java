package travelAgency.services;

public class TravelAgencyException extends Exception {
    public TravelAgencyException() { }

    public TravelAgencyException(String message) { super(message); }

    public TravelAgencyException(String message, Throwable cause) { super(message, cause); }
}
