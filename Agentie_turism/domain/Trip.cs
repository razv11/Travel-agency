using System;

namespace Agentie_turism.domain
{
    public class Trip : Entity<long>
    {
        public string Landmark { get; set; }
        public string TransportCompanyName { get; set; }
        public DateTime DepartureTime { get; set; }
        public float Price { get; set; }
        public int AvailableSeats { get; set; }

        public Trip(string landmark, string transportCompanyName, DateTime departureTime, float price, int availableSetas)
        {
            Landmark = landmark;
            TransportCompanyName = transportCompanyName;
            DepartureTime = departureTime;
            Price = price;
            AvailableSeats = availableSetas;
        }

        public override string ToString()
        {
            return "ID: " + Id + " | Landmark: " + Landmark + " | Company: " + TransportCompanyName + " | Seats: " + AvailableSeats;
        }
    }
}