using model;

namespace services
{
    public interface ITravelAgencyServices
    {
        void Login(User user, ITravelAgencyObserver client);
        void ReserveTrip(Reservation reservation);
        void Logout(User user, ITravelAgencyObserver client);
        Trip[] GetTrips();
        Trip[] GetSearchedTrips(string landmark, int startHour, int endHour);
    }
}