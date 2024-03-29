package ro.ubbcluj.mpp.service;

import ro.ubbcluj.mpp.domain.Trip;
import ro.ubbcluj.mpp.repository.tripRepo.TripsDBRepository;

import java.util.List;
import java.util.Optional;

public class TripService {
    private final TripsDBRepository repo;

    public TripService(TripsDBRepository repo) {
        this.repo = repo;
    }

    public Iterable<Trip> findAll(){
        return repo.findAll();
    }

    public List<Trip> findTripsBetweenHoursHavingLandmark(int startHour, int endHour, String landmark){
        return repo.findBetweenHoursHavingLandmark(startHour, endHour, landmark);
    }

    public Optional<Trip> updateNumberOfSeats(Trip trip, int noSeats) {
        trip.setAvailableSeats(trip.getAvailableSeats() - noSeats);
        return repo.update(trip);
    }
}
