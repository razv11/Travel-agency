package travelAgency.persistence;

import travelAgency.model.Trip;

import java.util.List;
import java.util.Optional;

public interface TripRepository extends Repository<Long, Trip> {
    List<Trip> findByLandmark(String landmark);
    List<Trip> findBetweenHoursHavingLandmark(int startHour, int endHour, String landmark);
    Optional<Trip> delete(Long id);
}
