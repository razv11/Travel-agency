using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model;
using persistence.reservationRepo;
using persistence.tripRepo;
using persistence.userRepo;
using services;

namespace server.server
{

    public class TravelAgencyServicesImplementation : ITravelAgencyServices
    {
        private IUserRepository _userRepository;
        private ITripRepository _tripRepository;
        private IReservationRepository _reservationRepository;
        private readonly IDictionary<string, ITravelAgencyObserver> _loggedClients;

        public TravelAgencyServicesImplementation(IUserRepository userRepository, ITripRepository tripRepository, IReservationRepository reservationRepository)
        {
            _userRepository = userRepository;
            _tripRepository = tripRepository;
            _reservationRepository = reservationRepository;
            _loggedClients = new Dictionary<string, ITravelAgencyObserver>();
        }

        #nullable enable
        public void Login(User user, ITravelAgencyObserver client)
        {
            User? targetUser = _userRepository.FindUserByUsername(user.Username);
            if (targetUser != null)
            {
                if (_loggedClients.ContainsKey(user.Username))
                {
                    throw new TravelAgencyException("User already logged!");
                    return;
                }

                if (user.Password == targetUser.Password)
                {
                    _loggedClients[user.Username] = client;
                    return;
                }
            }
            
            throw new TravelAgencyException("Authentication failed!");
        }

        public void ReserveTrip(Reservation reservation)
        {
            User? user = _userRepository.FindUserByUsername(reservation.AgencyUser.Username);
            if (user == null)
            {
                throw new TravelAgencyException("User unknown!");
            }

            reservation.AgencyUser.Id = user.Id;

            Reservation? newReservation = _reservationRepository.Save(reservation);
            if (newReservation != null)
            {
                throw new TravelAgencyException("Error while trying to save reservation");
            }

            Trip trip = reservation.CurrentTrip;
            trip.AvailableSeats = trip.AvailableSeats - reservation.NumberOfTickets;
            Trip? updatedTrip = _tripRepository.Update(trip);

            if (updatedTrip != null)
            {
                throw new TravelAgencyException("Error while trying to update trip");
            }

            NotifyUsersLoggedIn(reservation);
        }

        public Trip[] GetTrips()
        {
            IEnumerable<Trip> trips = _tripRepository.FindAll();
            return trips.ToArray();
        }
        
        public Trip[] GetSearchedTrips(string landmark, int startHour, int endHour)
        {
            IEnumerable<Trip> searchedTrips = _tripRepository.FindBetweenHoursHavingLandmark(landmark, startHour, endHour);
            return searchedTrips.ToArray();
        }

        public void Logout(User user, ITravelAgencyObserver client)
        {
            ITravelAgencyObserver loggedUser = _loggedClients[user.Username];
            if (loggedUser == null)
            {
                throw new TravelAgencyException("User " + user.Username + " is not logged in!");
            }

            _loggedClients.Remove(user.Username);
        }

        private void NotifyUsersLoggedIn(Reservation reservation)
        {
            foreach (ITravelAgencyObserver client in _loggedClients.Values)
            {
                Task.Run(() => client.TripReserved(reservation));
            }
        }
    }
}