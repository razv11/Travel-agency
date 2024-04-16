using System;

namespace client
{
    public enum TravelAgencyUserEvent
    {
        TripReserved
    }
    
    public class TravelAgencyUserEventArgs : EventArgs
    {
        private readonly TravelAgencyUserEvent _userEvent;
        private readonly object _data;

        public TravelAgencyUserEventArgs(TravelAgencyUserEvent userEvent, object data)
        {
            _userEvent = userEvent;
            _data = data;
        }

        public TravelAgencyUserEvent EventType
        {
            get
            {
                return _userEvent;
            }
        }

        public object Data
        {
            get
            {
                return _data;
            }
        }
    }
}