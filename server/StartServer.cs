using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using model;
using networking.objectprotocol;
using networking.utils;
using persistence.reservationRepo;
using persistence.tripRepo;
using persistence.userRepo;
using server.server;
using services;

namespace server
{
    public class StartServer
    {
        private static readonly string DefaultIp = "127.0.0.1";
        private static readonly int DefaultPort = 55555;

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading server properties...");

            int port = DefaultPort;
            string ip = DefaultIp;

            string serverPort = ConfigurationManager.AppSettings["port"];
            if (serverPort == null)
            {
                Console.WriteLine("Port property not set. Using default port: " + DefaultPort);
            }
            else
            {
                bool isNumber = Int32.TryParse(serverPort, out port);
                if (!isNumber)
                {
                    Console.WriteLine("Port property is not numberic. Using default port: " + DefaultPort);
                    port = DefaultPort;
                }
            }

            string serverIp = ConfigurationManager.AppSettings["ip"];
            if (serverIp == null)
            {
                Console.WriteLine("Ip property not set. Using default ip: " + DefaultIp);
            }
            else
            {
                ip = serverIp;
            }
            
            Console.WriteLine("Database property: " + GetConnectionStringByName("TravelAgencyDB"));

            IDictionary<string, string> props = new SortedList<string, string>();
            props.Add("ConnectionString", GetConnectionStringByName("TravelAgencyDB"));

            IUserRepository userRepository = new UserDbRepository(props);
            ITripRepository tripRepository = new TripDbRepository(props);
            IReservationRepository reservationRepository = new ReservationDbRepository(props);
            
            ITravelAgencyServices servicesImplementation = new TravelAgencyServicesImplementation(userRepository, tripRepository, reservationRepository);
            
            Console.WriteLine("Starting server using IP {0} and Port {1}", serverIp, serverPort);
            TravelAgencySerialConcurrentServer server = new TravelAgencySerialConcurrentServer(serverIp, port, servicesImplementation);
            server.Start();
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
    }

    public class TravelAgencySerialConcurrentServer : ConcurrentAbstractServer
    {
        private readonly ITravelAgencyServices _server;
        private TravelAgencyClientObjectWorker _worker;

        public TravelAgencySerialConcurrentServer(string host, int port, ITravelAgencyServices server) : base(host, port)
        {
            _server = server;
            Console.WriteLine("Initializing TravelAgencySerialConcurrentServer..");
        }

        protected override Thread CreateWorker(TcpClient client)
        {
            _worker = new TravelAgencyClientObjectWorker(_server, client);
            return new Thread(new ThreadStart(_worker.Run));
        }
    }
}