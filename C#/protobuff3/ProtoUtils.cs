using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;

namespace protobuff3
{
    public class ProtoUtils
    {
        public static Request CreateLoginRequest(model.User user)
        {
            User userDTO = new User { Id = user.Id, Username = user.Username, Password = user.Password };
            Request request = new Request { Type = Request.Types.RequestType.Login, User = userDTO };

            return request;
        }

        public static Request CreateLogoutRequest(model.User user)
        {
            User userDTO = new User { Id = user.Id, Username  = user.Username, Password = user.Password };
            Request request = new Request { Type = Request.Types.RequestType.Logout, User = userDTO };

            return request;
        }

        public static Request CreateReserveTripRequest(model.Reservation reservation)
        {
            User user = new User { Id = reservation.AgencyUser.Id, Username = reservation.AgencyUser.Username, Password = reservation.AgencyUser.Password };
            Trip trip = new Trip { Id = reservation.CurrentTrip.Id, TransportCompanyName = reservation.CurrentTrip.TransportCompanyName, Landmark = reservation.CurrentTrip.Landmark, Price = reservation.CurrentTrip.Price, AvailableSeats = reservation.CurrentTrip.AvailableSeats  };
            Reservation newReservation = new Reservation
            {
                ClientName = reservation.ClientName, 
                PhoneNumber = reservation.PhoneNumber,
                NumberOfTickets = reservation.NumberOfTickets,
                User = user,
                Trip = trip
            };
            
            Request request = new Request { Type = Request.Types.RequestType.ReserveTrip, Reservation = newReservation };
            return request;
        }

        public static Request CreateGetAllTripsRequest()
        {
            Request request = new Request { Type = Request.Types.RequestType.GetAllTrips };
            return request;
        }

        public static Request CreateGetSearchedTripsRequest(string landmark, int startHour, int endHour)
        {
            Request request = new Request { Type = Request.Types.RequestType.GetSearchedTrips, Landmark = landmark, StartHour = startHour, EndHour = endHour };
            return request;
        }

        public static model.Reservation getReservation(Response response)
        {
            model.Reservation reservation = new model.Reservation();
            reservation.ClientName = response.Reservation.ClientName;
            reservation.PhoneNumber = response.Reservation.PhoneNumber;

            model.Trip trip = new model.Trip();
            trip.Landmark = response.Reservation.Trip.Landmark;
            trip.AvailableSeats = response.Reservation.Trip.AvailableSeats;
            trip.Id = response.Reservation.Trip.Id;
            trip.TransportCompanyName = response.Reservation.Trip.TransportCompanyName;
            trip.Price = response.Reservation.Trip.Price;
            //trip.DepartureTime = DateTime.Parse(response.Reservation.Trip.DepartureTime);

            model.User user = new model.User(null, null);
            user.Id = response.Reservation.User.Id;
            user.Username = response.Reservation.User.Username;
            user.Password = response.Reservation.User.Password;
            
            reservation.CurrentTrip = trip;
            reservation.AgencyUser = user;
            
            return reservation;
        }

        public static model.Trip[] getTrips(Response response)
        {
            model.Trip[] trips = new model.Trip[response.Trips.Count];
            for (int i = 0; i < response.Trips.Count; ++i)
            {
                model.Trip trip = new model.Trip();
                trip.Id = response.Trips[i].Id;
                trip.Landmark = response.Trips[i].Landmark;
                trip.AvailableSeats = response.Trips[i].AvailableSeats;
                trip.TransportCompanyName = response.Trips[i].TransportCompanyName;
                trip.DepartureTime = DateTime.Parse(response.Trips[i].DepartureTime);
                trip.Price = response.Trips[i].Price;
                
                trips[i] = trip;
            }

            return trips;
        }

        public static model.Trip[] getSearchedTrips(Response response)
        {
            model.Trip[] trips = new model.Trip[response.Trips.Count];
            for (int i = 0; i < response.Trips.Count; ++i)
            {
                model.Trip trip = new model.Trip();
                trip.Id = response.Trips[i].Id;
                trip.Landmark = response.Trips[i].Landmark;
                trip.AvailableSeats = response.Trips[i].AvailableSeats;
                trip.TransportCompanyName = response.Trips[i].TransportCompanyName;
                trip.DepartureTime = DateTime.Parse(response.Trips[i].DepartureTime);
                trip.Price = response.Trips[i].Price;
                
                trips[i] = trip;
            }

            return trips;
        }
    }
}