using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using model;
using networking.dto;
using services;

namespace networking.objectprotocol
{
    public class TravelAgencyServerObjectProxy : ITravelAgencyServices
    {
        private string _host;
        private int _port;
        private ITravelAgencyObserver _client;
        private BinaryFormatter _formatter;

        private NetworkStream _stream;
        private TcpClient _connection;

        private Queue<IResponse> _responses;
        private EventWaitHandle _waitHandle;
        private volatile bool _finished;

        public TravelAgencyServerObjectProxy(string host, int port)
        {
            _host = host;
            _port = port;
            _responses = new Queue<IResponse>();
        }

        private void StartReader()
        {
            Thread newThread = new Thread(Run);
            newThread.Start(); 
        }

        private void InitializeConnection()
        {
            try
            {
                _connection = new TcpClient(_host, _port);
                _stream = _connection.GetStream();
                _finished = false;
                _waitHandle = new AutoResetEvent(false);
                StartReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void CloseConnection()
        {
            _finished = true;
            try
            {
                _stream.Close();
                _connection.Close();
                _waitHandle.Close();
                _client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void SendRequest(IRequest request)
        {
            try
            {
                _formatter.Serialize(_stream, request);
                _stream.Flush();
            }
            catch (Exception e)
            {
                throw new TravelAgencyException("Error while trying to send object.." + e);
            }
        }

        private IResponse ReadResponse()
        {
            IResponse response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (_responses)
                {
                    response = _responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;
        }

        public virtual void Login(User user, ITravelAgencyObserver client)
        {
            InitializeConnection();
            SendRequest(new LoginRequest(user));
            IResponse response = ReadResponse();

            if (response is OkResponse)
            {
                _client = client;
                return;
            }

            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse)response;
                CloseConnection();
                throw new TravelAgencyException(errorResponse.Message);
            }
        }

        public virtual void ReserveTrip(Reservation reservation)
        {
            SendRequest(new ReserveTripRequest(reservation));
            IResponse response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse)response;
                throw new TravelAgencyException(errorResponse.Message);
            }
        }

        public virtual Trip[] GetTrips()
        {
            SendRequest(new GetTripsRequest());
            IResponse receivedResponse = ReadResponse();
            if (receivedResponse is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse)receivedResponse;
                throw new TravelAgencyException(errorResponse.Message);
            }

            GetAllTripsResponse response = (GetAllTripsResponse)receivedResponse;
            return response.Trips.ToArray();
        }

        public virtual Trip[] GetSearchedTrips(string landmark, int startHour, int endHour)
        {
            FilterDTO filter = new FilterDTO(landmark, startHour, endHour);
            SendRequest(new GetSearchedTripsRequest(filter));
            IResponse receivedResponse = ReadResponse();
            if (receivedResponse is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse)receivedResponse;
                throw new TravelAgencyException(errorResponse.Message);
            }

            GetSearchedTripsResponse response = (GetSearchedTripsResponse)receivedResponse;
            return response.Trips.ToArray();
        }

        public virtual void Logout(User user, ITravelAgencyObserver client)
        {
            SendRequest(new LogoutRequest(user));
            IResponse receivedResponse = ReadResponse();
            CloseConnection();
            _client = null;
            if (receivedResponse is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse)receivedResponse;
                throw new TravelAgencyException(errorResponse.Message);
            }
        }

        private void HandleUpdateResponse(IUpdateResponse response)
        {
            if (response is TripReservedResponse)
            {
                TripReservedResponse tripReserved = (TripReservedResponse)response;
                Reservation reservation = tripReserved.Reservation;
                try
                {
                    _client.TripReserved(reservation);
                }
                catch (TravelAgencyException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        
        protected virtual void Run()
        {
            while (!_finished)
            {
                try
                {
                    object response = _formatter.Deserialize(_stream);
                    Console.WriteLine("Response received: " + response);
                    if (response is IUpdateResponse)
                    {
                        HandleUpdateResponse((IUpdateResponse)response);
                    }
                    else
                    {
                        lock (response)
                        {
                            _responses.Enqueue((IResponse)response);
                        }

                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while trying to read response: " + e);
                }
            }
        }
    }
}