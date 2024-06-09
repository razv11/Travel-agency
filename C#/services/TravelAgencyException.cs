using System;

namespace services
{
    public class TravelAgencyException : Exception
    {
        public TravelAgencyException() : base() { }
        public TravelAgencyException(string message) : base(message) { }
        public TravelAgencyException(string message, Exception exception) : base(message, exception) { }
    }
}