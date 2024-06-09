using System;
using Newtonsoft.Json;

namespace model
{
    [Serializable]
    public class Trip : Entity<long>
    {
        [JsonProperty("landmark")]
        public string Landmark { get; set; }
        
        [JsonProperty("companyname")]
        public string TransportCompanyName { get; set; }
        
        [JsonProperty("departuretime")]
        public DateTime DepartureTime { get; set; }
        
        [JsonProperty("price")]
        public float Price { get; set; }
        
        [JsonProperty("seats")]
        public int AvailableSeats { get; set; }

        public Trip() { }
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