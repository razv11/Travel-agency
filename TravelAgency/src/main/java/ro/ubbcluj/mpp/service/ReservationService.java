package ro.ubbcluj.mpp.service;

import ro.ubbcluj.mpp.domain.Reservation;
import ro.ubbcluj.mpp.repository.reservationRepo.ReservationsDBRepository;

import java.util.Optional;

public class ReservationService {
    private final ReservationsDBRepository repo;

    public ReservationService(ReservationsDBRepository repository) {
        this.repo = repository;
    }

    public Optional<Reservation> save(String clientName, Long phoneNumber, int noSeats, Long userId, Long tripId) {
        Reservation newReservation = new Reservation(clientName, phoneNumber, noSeats, userId, tripId);
        return repo.save(newReservation);
    }
}
