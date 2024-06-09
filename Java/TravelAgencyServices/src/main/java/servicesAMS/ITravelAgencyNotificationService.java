package servicesAMS;

import travelAgency.model.Reservation;

public interface ITravelAgencyNotificationService {
    void newReservation(Reservation reservation);
}
