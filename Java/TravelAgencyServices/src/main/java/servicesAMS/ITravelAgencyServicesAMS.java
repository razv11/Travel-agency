package servicesAMS;

import travelAgency.model.Reservation;
import travelAgency.model.User;
import travelAgency.model.Trip;
import travelAgency.services.TravelAgencyException;

public interface ITravelAgencyServicesAMS {
    void login(User user) throws TravelAgencyException;
    Trip[] getTrips() throws TravelAgencyException;
    void reserveTrip(Reservation reservation) throws TravelAgencyException;
    Trip[] getSearchedTrips(String landmark, int startHour, int endHour) throws TravelAgencyException;
    void logout(User user) throws TravelAgencyException;
}
