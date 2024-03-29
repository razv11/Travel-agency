package ro.ubbcluj.mpp.repository.tripRepo;

import ro.ubbcluj.mpp.domain.Trip;
import ro.ubbcluj.mpp.repository.Repository;

import java.util.List;

public interface TripRepository extends Repository<Long, Trip> {
    List<Trip> findByLandmark(String landmark);
    List<Trip> findBetweenHoursHavingLandmark(int startHour, int endHour, String landmark);
}
