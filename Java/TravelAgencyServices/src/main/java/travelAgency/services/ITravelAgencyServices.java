package travelAgency.services;

import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
public interface ITravelAgencyServices {
    void login(User user, ITravelAgencyObserver client) throws TravelAgencyException;
    void reserveTrip(Reservation reservation) throws TravelAgencyException;
    void logout(User user, ITravelAgencyObserver client) throws TravelAgencyException;
    Trip[] getTrips() throws TravelAgencyException;
    Trip[] getSearchedTrips(String landmark, int startHour, int endHour) throws TravelAgencyException;
}
