using System;
using model;
using networking.dto;

namespace networking.objectprotocol
{
    public interface IRequest
    {
        
    }
    
    [Serializable]
    public class LoginRequest : IRequest
    {
        private User _user;

        public LoginRequest(User user)
        {
            _user = user;
        }

        public virtual User User
        {
            get
            {
                return _user;
            }
        }
    }

    [Serializable]
    public class ReserveTripRequest : IRequest
    {
        private Reservation _reservation;

        public ReserveTripRequest(Reservation reservation)
        {
            _reservation = reservation;
        }

        public virtual Reservation Reservation
        {
            get
            {
                return _reservation;
            }
        }
    }

    [Serializable]
    public class GetTripsRequest : IRequest
    {
        
    }

    [Serializable]
    public class GetSearchedTripsRequest : IRequest
    {
        private FilterDTO _filter;

        public GetSearchedTripsRequest(FilterDTO filter)
        {
            _filter = filter;
        }

        public virtual FilterDTO Filter
        {
            get
            {
                return _filter;
            }
        }
    }

    [Serializable]
    public class LogoutRequest : IRequest
    {
        private User _user;

        public LogoutRequest(User user)
        {
            _user = user;
        }

        public virtual User User
        {
            get
            {
                return _user;
            }
        }
    }
}