using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Google.Protobuf;
using networking.dto;
using services;

namespace protobuff3
{
    public class ProtoTravelAgencyProxy : ITravelAgencyServices
    {
        private string _host;
        private int _port;
        private ITravelAgencyObserver _client;
        private TcpClient _connection;

        private NetworkStream _stream;

        private Queue<Response> _responses;
        private EventWaitHandle _waitHandle;
        private volatile bool _finished;

        public ProtoTravelAgencyProxy(string host, int port)
        {
            _host = host;
            _port = port;
            _responses = new Queue<Response>();
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

        private void SendRequest(Request request)
        {
            try
            {
                request.WriteDelimitedTo(_stream);
                _stream.Flush();
            }
            catch (Exception e)
            {
                throw new TravelAgencyException("Error while trying to send object.." + e);
            }
        }

        private Response ReadResponse()
        {
            Response response = null;
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

        public virtual void Login(model.User user, ITravelAgencyObserver client)
        {
            InitializeConnection();
            SendRequest(ProtoUtils.CreateLoginRequest(user));
            Response response = ReadResponse();

            if (response.Type == Response.Types.ResponseType.Ok)
            {
                _client = client;
                return;
            }

            if (response.Type == Response.Types.ResponseType.Error)
            {
                CloseConnection();
                throw new TravelAgencyException(response.ErrorMessage);
            }
        }

        public virtual void ReserveTrip(model.Reservation reservation)
        {
            SendRequest(ProtoUtils.CreateReserveTripRequest(reservation));
            Response response = ReadResponse();
            if (response.Type == Response.Types.ResponseType.Error)
            {
                throw new TravelAgencyException(response.ErrorMessage);
            }
        }

        public virtual model.Trip[] GetTrips()
        {
            SendRequest(ProtoUtils.CreateGetAllTripsRequest());
            Response receivedResponse = ReadResponse();
            if (receivedResponse.Type == Response.Types.ResponseType.Error)
            {
                throw new TravelAgencyException(receivedResponse.ErrorMessage);
            }
            
            return ProtoUtils.getTrips(receivedResponse);
        }

        public virtual model.Trip[] GetSearchedTrips(string landmark, int startHour, int endHour)
        {
            SendRequest(ProtoUtils.CreateGetSearchedTripsRequest(landmark, startHour, endHour));
            Response receivedResponse = ReadResponse();
            if (receivedResponse.Type == Response.Types.ResponseType.Error)
            {
                throw new TravelAgencyException(receivedResponse.ErrorMessage);
            }
        
            return ProtoUtils.getSearchedTrips(receivedResponse);
        }

        public virtual void Logout(model.User user, ITravelAgencyObserver client)
        {
            SendRequest(ProtoUtils.CreateLogoutRequest(user));
            Response receivedResponse = ReadResponse();
            if (receivedResponse.Type == Response.Types.ResponseType.Error)
            {
                throw new TravelAgencyException(receivedResponse.ErrorMessage);
            }
            CloseConnection();
            _client = null;
        }

        private void HandleUpdateResponse(Response response)
        {
            if (response.Type == Response.Types.ResponseType.TripReserved)
            {
                try
                {
                    _client.TripReserved(ProtoUtils.getReservation(response));
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
                    Response response = Response.Parser.ParseDelimitedFrom(_stream);
                    Console.WriteLine("Response received: " + response);
                    if (response.Type == Response.Types.ResponseType.TripReserved)
                    {
                        HandleUpdateResponse(response);
                    }
                    else
                    {
                        lock (response)
                        {
                            _responses.Enqueue(response);
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