package travelAgency.server;

import at.favre.lib.crypto.bcrypt.BCrypt;
import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.persistence.ReservationRepository;
import travelAgency.persistence.TripRepository;
import travelAgency.persistence.UserRepository;
import travelAgency.services.ITravelAgencyObserver;
import travelAgency.services.ITravelAgencyServices;
import travelAgency.services.TravelAgencyException;

import java.io.Console;
import java.lang.constant.Constable;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class TravelAgencyServicesImplementation implements ITravelAgencyServices {
    private final int defaulThreadsNo = 5;
    private UserRepository userRepository;
    private TripRepository tripRepository;
    private ReservationRepository reservationRepository;
    private Map<String, ITravelAgencyObserver> loggedUsers;

    public TravelAgencyServicesImplementation(UserRepository userRepository, TripRepository tripRepository, ReservationRepository reservationRepository) {
        this.userRepository = userRepository;
        this.tripRepository = tripRepository;
        this.reservationRepository = reservationRepository;

        //userRepository.save(new User("razvan", "razvan"));
        loggedUsers = new ConcurrentHashMap<>();
    }

    private String hashPassword(String password) {
        // Hash a password
        return BCrypt.withDefaults().hashToString(12, password.toCharArray());
    }

    private void notifyUsersLoggedIn(Reservation reservation) throws TravelAgencyException {
        ExecutorService executor = Executors.newFixedThreadPool(defaulThreadsNo);
        for(ITravelAgencyObserver travelAgencyClient : loggedUsers.values()) {
            executor.execute(() -> {
                try {
                    travelAgencyClient.tripReserved(reservation);
                } catch (TravelAgencyException e) {
                    System.err.println("Error notifying user " + e);
                }
            });
        }
    }

    @Override
    public synchronized void login(User user, ITravelAgencyObserver client) throws TravelAgencyException {
        Optional<User> nUser = userRepository.findUserByUsername(user.getUsername());

        if(nUser.isPresent()) {
            if(nUser.get().getPassword().equals(user.getPassword())) {
                if(loggedUsers.get(user.getUsername()) != null) {
                    throw new TravelAgencyException("User already logged in");
                } else {
                    loggedUsers.put(user.getUsername(), client);
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
        User user = reservation.getAgencyUser();
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

        notifyUsersLoggedIn(reservation);
    }

    @Override
    public void logout(User user, ITravelAgencyObserver client) throws TravelAgencyException {
        ITravelAgencyObserver localUser = loggedUsers.remove(user.getUsername());
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
