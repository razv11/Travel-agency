using System;
using System.Configuration;
using System.Windows.Forms;
using networking.objectprotocol;
using services;

namespace client
{
    static class StartTravelAgencyClient
    {
        private static readonly string DefaultHost = "127.0.0.1";
        private static readonly int DefaultPort = 55555;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string host;
            try
            {
                host = ConfigurationManager.AppSettings["host"];
            }
            catch (Exception exception)
            {
                host = DefaultHost;
                Console.WriteLine("Host property not set. Using default host: {0}", host);
            }

            string portStr;
            int port;
            try
            {
                portStr = ConfigurationManager.AppSettings["port"];
                try
                {
                    port = int.Parse(portStr);
                }
                catch (Exception ex)
                {
                    port = DefaultPort;
                    Console.WriteLine("Port property is not numeric. Using default port: {0}", port);
                }
            }
            catch (Exception e)
            {
                port = DefaultPort;
                Console.WriteLine("Port property not set. Using default port: {0}", port);
            }

            ITravelAgencyServices server = new TravelAgencyServerObjectProxy(host, port);
            TravelAgencyClientController controller = new TravelAgencyClientController(server);
            LoginWindow loginWindow = new LoginWindow(controller);
            Application.Run(loginWindow);
        }
    }
}