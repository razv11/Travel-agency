package servicesAMS;

import travelAgency.model.Reservation;
import travelAgency.services.TravelAgencyException;

public interface ITravelAgencyClient {
    void tripReserved(Reservation reservation) throws TravelAgencyException;
}
