using model;

namespace services
{
    public interface ITravelAgencyObserver
    {
        void TripReserved(Reservation reservation);
    }
}