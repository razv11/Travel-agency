using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using model;

namespace persistence.tripRepo;

public class TripDbRepository : ITripRepository
{
    private static readonly ILog Log = LogManager.GetLogger("TripDbRepository");
    private IDictionary<string, string> _props;

    public TripDbRepository(IDictionary<string, string> props)
    {
        Log.Info("Creating TripDbRepository...");
        _props = props;
    }
    
    public IEnumerable<Trip> FindAll()
    {
        Log.InfoFormat("Enetering FindAll() from TripDbRepository");
        IDbConnection con = DbUtils.GetConnection(_props);
        List<Trip> trips = new List<Trip>();

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT * FROM Trips";
            using (var resultSet = comm.ExecuteReader())
            {
                while (resultSet.Read())
                {
                    int id = resultSet.GetInt32(0);
                    string transportCompanyName = resultSet.GetString(1);
                    DateTime departureTime = resultSet.GetDateTime(2);
                    float price = resultSet.GetFloat(3);
                    int availableSeats = resultSet.GetInt32(4);
                    string landmark = resultSet.GetString(5);

                    Trip trip = new Trip(landmark, transportCompanyName, departureTime, price, availableSeats);
                    trip.Id = id;
                    trips.Add(trip);
                }
            }
        }
        
        Log.InfoFormat("Exiting FindAll() from TripDbRepository");
        return trips;
    }

    public List<Trip> FindBetweenHoursHavingLandmark(string landmark, int startHour, int endHour)
    {
        Log.InfoFormat("Entering FindBetweenHoursHavingLandmark() from TripDbRepository");
        IDbConnection con = DbUtils.GetConnection(_props);
        List<Trip> filteredTrips = new List<Trip>();

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT * FROM Trips WHERE landmark = @landmark AND strftime('%H', departureTime) >= @StartHour AND strftime('%H', departureTime) < @EndHour";
            IDbDataParameter paramLandmark = comm.CreateParameter();
            paramLandmark.ParameterName = "@landmark";
            paramLandmark.Value = landmark.ToUpper();
            comm.Parameters.Add(paramLandmark);

            IDbDataParameter paramStartHour = comm.CreateParameter();
            paramStartHour.ParameterName = "@StartHour";
            paramStartHour.Value = startHour.ToString();
            comm.Parameters.Add(paramStartHour);

            IDbDataParameter paramEndHour = comm.CreateParameter();
            paramEndHour.ParameterName = "@EndHour";
            paramEndHour.Value = endHour.ToString();
            comm.Parameters.Add(paramEndHour);

            using (var resultSet = comm.ExecuteReader())
            {
                while (resultSet.Read())
                {
                    int id = resultSet.GetInt32(0);
                    string transportCompanyName = resultSet.GetString(1);
                    DateTime departureTime = resultSet.GetDateTime(2);
                    float price = resultSet.GetFloat(3);
                    int availableSeats = resultSet.GetInt32(4);

                    Trip trip = new Trip(landmark, transportCompanyName, departureTime, price, availableSeats);
                    trip.Id = id;
                    filteredTrips.Add(trip);
                }
            }
        }

        Log.InfoFormat("Exiting FindBetweenHoursHavingLandmark() from TripDbRepository");
        return filteredTrips;
    }

    #nullable enable
    public Trip? Save(Trip entity)
    {
        Log.InfoFormat("Entering Save() from TripDbRepository with landmark {0}", entity.Landmark);
        IDbConnection con = DbUtils.GetConnection(_props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "INSERT INTO Trips(transportCompanyName, departureTime, price, availableSeats, landmark) VALUES (@tCN, @dT, @p, @aS, @l)";
            IDbDataParameter paramTransportCompanyName = comm.CreateParameter();
            paramTransportCompanyName.ParameterName = "@tCN";
            paramTransportCompanyName.Value = entity.TransportCompanyName;
            comm.Parameters.Add(paramTransportCompanyName);

            IDbDataParameter paramDepartureTime = comm.CreateParameter();
            paramDepartureTime.ParameterName = "@dT";
            paramDepartureTime.Value = entity.DepartureTime;
            comm.Parameters.Add(paramDepartureTime);

            IDbDataParameter paramPrice = comm.CreateParameter();
            paramPrice.ParameterName = "@p";
            paramPrice.Value = entity.Price;
            comm.Parameters.Add(paramPrice);

            IDbDataParameter paramAvailableSeats = comm.CreateParameter();
            paramAvailableSeats.ParameterName = "@aS";
            paramAvailableSeats.Value = entity.AvailableSeats;
            comm.Parameters.Add(paramAvailableSeats);

            IDbDataParameter paramLandmark = comm.CreateParameter();
            paramLandmark.ParameterName = "@l";
            paramLandmark.Value = entity.Landmark.ToUpper();
            comm.Parameters.Add(paramLandmark);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
            {
                Log.Error("Error while trying to save Trip with landmark " + entity.Landmark);
                return entity;
            }
        }
        
        Log.InfoFormat("Exiting Save() from TripDbRepository with landmark {0}", entity.Landmark);
        return null;
    }

    public Trip? Update(Trip entity)
    {
        Log.InfoFormat("Enetering Update() from TripDbRepository with id {0}", entity.Id);
        IDbConnection con = DbUtils.GetConnection(_props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "UPDATE Trips SET availableSeats=@aS WHERE id=@id";
            IDbDataParameter paramAvailableSeats = comm.CreateParameter();
            paramAvailableSeats.ParameterName = "@aS";
            paramAvailableSeats.Value = entity.AvailableSeats;
            comm.Parameters.Add(paramAvailableSeats);

            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = entity.Id;
            comm.Parameters.Add(paramId);
            
            var result = comm.ExecuteNonQuery();
            if (result == 0)
            {
                Log.Error("Error while trying to update Trip with id " + entity.Id);
                return entity;
            }
        }
        
        Log.InfoFormat("Exiting Update() from TripDbRepository with tripId = {0}", entity.Id);
        return null;
    }
}