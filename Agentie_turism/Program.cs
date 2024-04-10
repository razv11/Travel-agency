using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Agentie_turism.domain;
using Agentie_turism.repository.reservationRepo;
using Agentie_turism.repository.tripRepo;
using Agentie_turism.repository.userRepo;
using log4net.Config;

namespace Agentie_turism
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            IDictionary<string, string> props = new SortedList<string, string>();
            props.Add("ConnectionString", GetConnectionStringByName("AgentieTurismDB"));
            
            // TestDb(props);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(props));
        }

        private static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        private static void TestDb(IDictionary<string, string> props)
        {
            UserDbRepository userDbRepository = new UserDbRepository(props);
            foreach (User u in userDbRepository.FindAll())
            {
                Console.WriteLine(u);
            }

            Console.WriteLine("here");
            TripDbRepository tripDbRepository = new TripDbRepository(props);
            Trip trip1 = new Trip("Roma", "Tarom", DateTime.Now, 200, 150);
            Trip trip2 = new Trip("Paris", "Wizzair", DateTime.Now, 300, 200);
            Trip trip3 = new Trip("Milano", "BlueAir", DateTime.Now, 180, 100);

            tripDbRepository.Save(trip1);
            tripDbRepository.Save(trip2);
            tripDbRepository.Save(trip3);

            foreach (var trip in tripDbRepository.FindAll())
            {
                Console.WriteLine(trip);
            }

            trip1.AvailableSeats = 100;
            tripDbRepository.Update(trip1);
            Console.WriteLine(@"Modified trip: " + trip1);

            ReservationDbRepository reservationDbRepository = new ReservationDbRepository(props);
            Reservation reservation1 = new Reservation("Razvan", "1234", 2, userDbRepository.FindUserByUsername("razvan"), trip1);
            reservationDbRepository.Save(reservation1);
            
            foreach (var reservation in reservationDbRepository.FindAll())
            {
                Console.WriteLine(reservation);
            }
        }
    }
}