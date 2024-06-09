package travelAgency.serverAMS;

import servicesAMS.ITravelAgencyServicesAMS;
import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.persistence.ReservationRepository;
import travelAgency.persistence.TripRepository;
import travelAgency.persistence.UserRepository;
import travelAgency.services.ITravelAgencyObserver;
import travelAgency.services.TravelAgencyException;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ConcurrentHashMap;

public class TravelAgencyServerAMSImpl implements ITravelAgencyServicesAMS {
    private final int defaulThreadsNo = 5;
    private UserRepository userRepository;
    private TripRepository tripRepository;
    private ReservationRepository reservationRepository;
    private NotificationServiceImpl notificationService;
    private Map<String, User> loggedUsers;

    public TravelAgencyServerAMSImpl(UserRepository userRepository, TripRepository tripRepository, ReservationRepository reservationRepository, NotificationServiceImpl notificationService) {
        this.userRepository = userRepository;
        this.tripRepository = tripRepository;
        this.reservationRepository = reservationRepository;
        this.notificationService = notificationService;

        loggedUsers = new ConcurrentHashMap<>();
    }

    @Override
    public synchronized void login(User user) throws TravelAgencyException {
        Optional<User> nUser = userRepository.findUserByUsername(user.getUsername());

        if(nUser.isPresent()) {
            if(nUser.get().getPassword().equals(user.getPassword())) {
                if(loggedUsers.get(user.getUsername()) != null) {
                    throw new TravelAgencyException("User already logged in");
                } else {
                    loggedUsers.put(user.getUsername(), user);
                }
            } else {
                throw new TravelAgencyException("Authentication failed");
            }
        }
        else {
            throw new TravelAgencyException("Authentication failed");
        }
    }

    @Override
    public void reserveTrip(Reservation reservation) throws TravelAgencyException {
        Optional<User> nUser = userRepository.findUserByUsername(reservation.getAgencyUser().getUsername());
        reservation.getAgencyUser().setId(nUser.get().getId());
        Optional<Reservation> nReservation = reservationRepository.save(reservation);

        Trip trip = reservation.getTrip();
        trip.setAvailableSeats(trip.getAvailableSeats() - reservation.getNumberOfTickets());
        Optional<Trip> tripU = tripRepository.update(trip.getId(), trip);

        if(nReservation.isPresent()) {
            throw new TravelAgencyException("Error while saving reservation");
        }

        if(tripU.isPresent()) {
            throw new TravelAgencyException("Error while trying to update trip");
        }

        notificationService.newReservation(reservation);
    }

    @Override
    public void logout(User user) throws TravelAgencyException {
        User localUser = loggedUsers.remove(user.getUsername());
        if(localUser == null) {
            throw new TravelAgencyException("User is not logged in");
        }
    }

    @Override
    public Trip[] getTrips() throws TravelAgencyException {
        Iterable<Trip> tripsIterable = tripRepository.findAll();

        List<Trip> tripList = new ArrayList<>();
        tripsIterable.forEach(tripList::add);

        return tripList.toArray(new Trip[0]);
    }

    @Override
    public Trip[] getSearchedTrips(String landmark, int startHour, int endHour) throws TravelAgencyException {
        List<Trip> tripIterable = tripRepository.findBetweenHoursHavingLandmark(startHour, endHour, landmark);
        return tripIterable.toArray(new Trip[0]);
    }
}
