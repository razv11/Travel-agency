using System.Collections.Generic;
using model;

namespace persistence.tripRepo;

public interface ITripRepository : IRepository<long, Trip>
{
    List<Trip> FindBetweenHoursHavingLandmark(string landmark, int startHour, int endHour);
}