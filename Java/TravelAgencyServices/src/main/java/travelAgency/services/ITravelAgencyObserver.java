package travelAgency.services;

import travelAgency.model.Reservation;

public interface ITravelAgencyObserver {
    void tripReserved(Reservation reservation) throws TravelAgencyException;
}
