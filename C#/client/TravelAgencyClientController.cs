using System;
using System.Collections;
using model;
using services;

namespace client
{
    public class TravelAgencyClientController : ITravelAgencyObserver
    {
        public event EventHandler<TravelAgencyUserEventArgs> UpdateEvent;
        private readonly ITravelAgencyServices _server;
        private model.User _currentUser;

        public TravelAgencyClientController(ITravelAgencyServices server)
        {
            _server = server;
            _currentUser = null;
        }

        public virtual void OnUserEvent(TravelAgencyUserEventArgs e)
        {
            if (UpdateEvent == null) return;
            UpdateEvent(this, e);
            Console.WriteLine(@"Update event called!");
        }
        
        public void TripReserved(model.Reservation reservation)
        {
            Console.WriteLine(@"Trip reserved {0}", reservation);
            TravelAgencyUserEventArgs args = new TravelAgencyUserEventArgs(TravelAgencyUserEvent.TripReserved, reservation);
            OnUserEvent(args);
        }
        
        public void Login(string username, string password)
        {
            model.User user = new model.User(username, password);
            _server.Login(user, this);
            _currentUser = user;
            Console.WriteLine(@"Current user: {0}", username);
        }
        
        public void ReserveTrip(string clientName, string phoneNumber, int noSeats, model.User user, model.Trip trip)
        {
            model.Reservation newReservation = new model.Reservation(clientName, phoneNumber, noSeats, user, trip);
            _server.ReserveTrip(newReservation);
        }

        public model.Trip[] GetAllTrips()
        {
            return _server.GetTrips();
        }

        public model.Trip[] GetSearchedTrips(string landmark, int startHour, int endHour)
        {
            return _server.GetSearchedTrips(landmark, startHour, endHour);
        }

        public void Logout()
        {
            Console.WriteLine(@"Logout for {0}", _currentUser.Username);
            _server.Logout(_currentUser, this);
            _currentUser = null;
        }
    }
}