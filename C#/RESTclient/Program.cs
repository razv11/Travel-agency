using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using model;

namespace RESTclient
{
    internal class Program
    {
        private static readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/travelagency/trips") };
        private static String URL = "http://localhost:8080/travelagency/trips";
        private const string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nPrint all trips:");
            await GetAllTrips();
            
            
            Console.WriteLine("\n\nPrint Trips to Madrid (between 12 and 14):");
            await GetTripsBetweenHoursHavingLandmark("paris", 12, 14);
            
            
            Console.WriteLine("\n\nAdding a new Trip..."); 
            string dateTimeString = "2024-06-19T12:30:00";
            Trip createdTrip = await CreateTrip(new Trip
                {
                    Landmark = "Madrid",
                    TransportCompanyName = "Company A",
                    DepartureTime = DateTime.ParseExact(dateTimeString, DateTimeFormat, null),
                    Price = 100.0f,
                    AvailableSeats = 50
                });
            
            
            Console.WriteLine("\n\nPrint all trips:");
            await GetAllTrips();
            
            
            Console.WriteLine("\n\nUpdating trip (set availableSeats = 500)...");
            createdTrip.AvailableSeats = 500;
            await UpdateTrip(createdTrip.Id, createdTrip);
            
            
            Console.WriteLine("\n\nPrint all trips:");
            await GetAllTrips();
            
            
            Console.WriteLine("\n\nDeleting trip with id: " + createdTrip.Id);
            await DeleteTrip(createdTrip.Id);
            
            
            Console.WriteLine("\n\nPrint all trips:");
            await GetAllTrips();
        }

        private static async Task GetAllTrips()
        {
            HttpResponseMessage response = await _client.GetAsync(URL);
            response.EnsureSuccessStatusCode();

            var trips = await response.Content.ReadFromJsonAsync<Trip[]>();
            Console.WriteLine("All trips:");
            foreach (var trip in trips)
            {
                Console.WriteLine(JsonSerializer.Serialize(trip, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        private static async Task GetTripsBetweenHoursHavingLandmark(string landmark, int startHour, int endHour)
        {
            HttpResponseMessage response = await _client.GetAsync( $"http://localhost:8080/travelagency/trips/search?landmark={landmark}&startHour={startHour}&endHour={endHour}");
            response.EnsureSuccessStatusCode();

            var trips = await response.Content.ReadFromJsonAsync<Trip[]>();
            Console.WriteLine($"Trips with landmark {landmark} between {startHour} and {endHour} hours:");
            foreach (var trip in trips)
            {
                Console.WriteLine(JsonSerializer.Serialize(trip, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        private static async Task<Trip> CreateTrip(Trip trip)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("http://localhost:8080/travelagency/trips", trip);
            response.EnsureSuccessStatusCode();

            var createdTrip = await response.Content.ReadFromJsonAsync<Trip>();
            Console.WriteLine("Created trip:");
            Console.WriteLine(JsonSerializer.Serialize(createdTrip, new JsonSerializerOptions { WriteIndented = true }));
            return createdTrip;
        }

        private static async Task UpdateTrip(long id, Trip trip)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"http://localhost:8080/travelagency/trips/{id}", trip);
            response.EnsureSuccessStatusCode();

            var updatedTrip = await response.Content.ReadFromJsonAsync<Trip>();
            Console.WriteLine("Updated trip:");
            Console.WriteLine(JsonSerializer.Serialize(updatedTrip, new JsonSerializerOptions { WriteIndented = true }));
        }

        private static async Task DeleteTrip(long id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"http://localhost:8080/travelagency/trips/{id}");
            response.EnsureSuccessStatusCode();

            Console.WriteLine($"Deleted trip with ID: {id}");
        }
    }
}