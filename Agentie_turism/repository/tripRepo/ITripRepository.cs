using System.Collections.Generic;
using Agentie_turism.domain;

namespace Agentie_turism.repository.tripRepo;

public interface ITripRepository : IRepository<long, Trip>
{
    List<Trip> FindBetweenHoursHavingLandmark(string landmark, int startHour, int endHour);
}