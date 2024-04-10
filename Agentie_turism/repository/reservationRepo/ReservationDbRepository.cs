using System;
using System.Collections.Generic;
using System.Data;
using Agentie_turism.domain;
using log4net;

namespace Agentie_turism.repository.reservationRepo;

public class ReservationDbRepository : IReservationRepository
{
    private static readonly ILog Log = LogManager.GetLogger("ReservationDbRepository");
    private IDictionary<string, string> _props;

    public ReservationDbRepository(IDictionary<string, string> props)
    {
        Log.Info("Creating ReservationDbRepository...");
        _props = props;
    }
    
    public IEnumerable<Reservation> FindAll()
    {
        Log.InfoFormat("Entering FindAll() from ReservationDbRepository");
        IDbConnection con = DbUtils.GetConnection(_props);
        List<Reservation> reservations = new List<Reservation>();

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT * FROM Reservations";

            using (var resultSet = comm.ExecuteReader())
            {
                while (resultSet.Read())
                {
                    int id = resultSet.GetInt32(0);
                    string clientName = resultSet.GetString(1);
                    string phoneNumber = resultSet.GetString(2);
                    int numberOfTickets = resultSet.GetInt32(3);
                    int userId = resultSet.GetInt32(4);
                    int tripId = resultSet.GetInt32(5);

                    User agencyTravelUser = new User(null, null);
                    agencyTravelUser.Id = userId;

                    Trip trip = new Trip(null, null, new DateTime(), -1, -1);
                    trip.Id = tripId;

                    Reservation reservation = new Reservation(clientName, phoneNumber, numberOfTickets, agencyTravelUser, trip);
                    reservation.Id = id;
                    reservations.Add(reservation);
                }
            }
        }
        
        Log.InfoFormat("Exiting FindAll() from ReservationDbRepository");
        return reservations;
    }
    
    #nullable enable
    public Reservation? Save(Reservation entity)
    {
        Log.InfoFormat("Entering Save() from ReservationDbRepository with value {0}", entity.ClientName);
        IDbConnection con = DbUtils.GetConnection(_props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "INSERT INTO Reservations(clientName, phoneNumber, numberOfTickets, idAgencyUser, idTrip) VALUES (@cN, @pN, @nT, @idUser, @idTrip)";
            IDbDataParameter paramClientName = comm.CreateParameter();
            paramClientName.ParameterName = "@cN";
            paramClientName.Value = entity.ClientName;
            comm.Parameters.Add(paramClientName);

            IDbDataParameter paramPhoneNumber = comm.CreateParameter();
            paramPhoneNumber.ParameterName = "@pN";
            paramPhoneNumber.Value = entity.PhoneNumber;
            comm.Parameters.Add(paramPhoneNumber);

            IDbDataParameter paramNumberOfTickets = comm.CreateParameter();
            paramNumberOfTickets.ParameterName = "@nT";
            paramNumberOfTickets.Value = entity.NumberOfTickets;
            comm.Parameters.Add(paramNumberOfTickets);

            IDbDataParameter paramUserId = comm.CreateParameter();
            paramUserId.ParameterName = "@idUser";
            paramUserId.Value = entity.AgencyUser.Id;
            comm.Parameters.Add(paramUserId);

            IDbDataParameter paramTripId = comm.CreateParameter();
            paramTripId.ParameterName = "@idTrip";
            paramTripId.Value = entity.CurrentTrip.Id;
            comm.Parameters.Add(paramTripId);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
            {
                Log.Error("Error while trying to save reservation with clientName " + entity.ClientName);
                return entity;
            }
        }
        
        Log.InfoFormat("Exiting Save() from ReservationDbRepository");
        return null;
    }

    public Reservation? Update(Reservation entity)
    {
        return null;
    }
}