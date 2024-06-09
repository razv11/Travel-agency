using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using model;
using networking.dto;
using services;

namespace networking.objectprotocol
{
    public class TravelAgencyClientObjectWorker : ITravelAgencyObserver
    {
        private ITravelAgencyServices _server;
        private TcpClient _connection;

        private NetworkStream _stream;
        private IFormatter _formatter;
        private volatile bool _connected;

        public TravelAgencyClientObjectWorker(ITravelAgencyServices server, TcpClient connection)
        {
            _server = server;
            _connection = connection;

            try
            {
                _stream = connection.GetStream();
                _formatter = new BinaryFormatter();
                _connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void SendResponse(IResponse response)
        {
            Console.WriteLine("Sending response: " + response);
            lock (_stream)
            {
                _formatter.Serialize(_stream, response);
                _stream.Flush();
            }
        }
        
        public void TripReserved(Reservation reservation)
        {
            Console.WriteLine("Book reserved: " + reservation);
            try
            {
                SendResponse(new TripReservedResponse(reservation));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private IResponse HandleRequest(IRequest request)
        {
            if (request is LoginRequest)
            {
                Console.WriteLine("Received login request..");
                LoginRequest loginRequest = (LoginRequest)request;
                User currentUser = loginRequest.User;

                try
                {
                    lock (_server)
                    {
                        _server.Login(currentUser, this);
                    }

                    return new OkResponse();
                }
                catch (Exception e)
                {
                    _connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is ReserveTripRequest)
            {
                Console.WriteLine("Received reserve trip request..");
                ReserveTripRequest reserveTripRequest = (ReserveTripRequest)request;
                Reservation reservation = reserveTripRequest.Reservation;

                try
                {
                    lock (_server)
                    {
                        _server.ReserveTrip(reservation);
                    }

                    return new OkResponse();
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetTripsRequest)
            {
                Console.WriteLine("Received get trips request..");
                
                try
                {
                    Trip[] trips;
                    lock (_server)
                    {
                        trips = _server.GetTrips();
                    }

                    return new GetAllTripsResponse(trips);
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetSearchedTripsRequest)
            {
                Console.WriteLine("Received get searched trips request..");
                GetSearchedTripsRequest getSearchedTripsRequest = (GetSearchedTripsRequest)request;
                FilterDTO filter = getSearchedTripsRequest.Filter;

                try
                {
                    Trip[] searchedTrips;
                    lock (_server)
                    {
                        searchedTrips = _server.GetSearchedTrips(filter.Landmark, filter.StratHour, filter.EndHour);
                    }

                    return new GetSearchedTripsResponse(searchedTrips);
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is LogoutRequest)
            {
                Console.WriteLine("Received logout request..");
                LogoutRequest logoutRequest = (LogoutRequest)request;
                User currentUser = logoutRequest.User;

                try
                {
                    lock (_server)
                    {
                        _server.Logout(currentUser, this);
                    }

                    _connected = false;
                    return new OkResponse();
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            return null;
        }
        
        public virtual void Run()
        {
            while (_connected)
            {
                try
                {
                    object request = _formatter.Deserialize(_stream);
                    object response = HandleRequest((IRequest)request);
                    if (response != null)
                    {
                        SendResponse((IResponse) response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            try
            {
                _stream.Close();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}