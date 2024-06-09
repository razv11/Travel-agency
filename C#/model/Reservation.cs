using System;

namespace model
{
    [Serializable]
    public class Reservation : Entity<long>
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfTickets { get; set; }
        public User AgencyUser { get; set; }
        public Trip CurrentTrip { get; set; }

        public Reservation()
        {
            
        }
        public Reservation(string clientName, string phoneNumber, int numberOfTickets, User agencyUser, Trip trip)
        {
            ClientName = clientName;
            PhoneNumber = phoneNumber;
            NumberOfTickets = numberOfTickets;
            AgencyUser = agencyUser;
            CurrentTrip = trip;
        }

        public override string ToString()
        {
            return "ID: " + Id + " | Client name: " + ClientName;
        }
    }
}