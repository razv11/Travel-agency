using System;
using model;

namespace networking.objectprotocol
{
    public interface IResponse
    {
        
    }
    
    [Serializable]
    public class OkResponse : IResponse
    {
        
    }

    [Serializable]
    public class ErrorResponse : IResponse
    {
        private string _errorMessage;

        public ErrorResponse(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public virtual string Message
        {
            get
            {
                return _errorMessage;
            }
        }
    }

    [Serializable]
    public class GetAllTripsResponse: IResponse
    {
        private Trip[] _allTrips;

        public GetAllTripsResponse(Trip[] allTrips)
        {
            _allTrips = allTrips;
        }

        public virtual Trip[] Trips
        {
            get
            {
                return _allTrips;
            }
        }
    }

    [Serializable]
    public class GetSearchedTripsResponse : IResponse
    {
        private Trip[] _searchedTrips;

        public GetSearchedTripsResponse(Trip[] searchedTrips)
        {
            _searchedTrips = searchedTrips;
        }

        public virtual Trip[] Trips
        {
            get
            {
                return _searchedTrips;
            }
        }
    }


    public interface IUpdateResponse : IResponse
    {
    }

    [Serializable]
    public class TripReservedResponse : IUpdateResponse
    {
        private Reservation _reservation;

        public TripReservedResponse(Reservation reservation)
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
}