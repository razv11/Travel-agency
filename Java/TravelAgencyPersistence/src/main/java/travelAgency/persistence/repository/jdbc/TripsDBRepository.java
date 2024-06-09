package travelAgency.persistence.repository.jdbc;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.stereotype.Component;
import travelAgency.model.Trip;
import travelAgency.persistence.TripRepository;

import java.sql.*;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Properties;
@Component
public class TripsDBRepository implements TripRepository {
    private JdbcUtils dbUtils;
    private static final Logger logger = LogManager.getLogger();

    public TripsDBRepository(Properties properties){
        logger.info("Initializing TripsDBRepository with proprieties: {} ", properties);
        dbUtils = new JdbcUtils(properties);
    }

    @Override
    public List<Trip> findByLandmark(String landmark) {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        List<Trip> trips = new ArrayList<>();

        try(PreparedStatement statement = connection.prepareStatement("SELECT * FROM trips WHERE landmark = ?")) {
            statement.setString(1, landmark);

            try(ResultSet result = statement.executeQuery()){
                while(result.next()){
                    Long id = result.getLong("id");
                    String transportComapanyName = result.getString("transportCompanyName");
                    LocalDateTime departureTime = LocalDateTime.parse(result.getString("departureTime"), DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
                    Float price = result.getFloat("price");
                    int availableSeats = result.getInt("availableSeats");

                    Trip trip = new Trip(landmark, transportComapanyName, departureTime, price, availableSeats);
                    trip.setId(id);

                    trips.add(trip);
                }
            }

        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }

        logger.traceExit(trips);
        return trips;
    }

    @Override
    public List<Trip> findBetweenHoursHavingLandmark(int startHour, int endHour, String landmark) {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        List<Trip> trips = new ArrayList<>();

        try(PreparedStatement statement = connection.prepareStatement("SELECT * FROM Trips WHERE  CAST(SUBSTR(departureTime, 12, 2) AS INTEGER) >= ? AND CAST(SUBSTR(departureTime, 12, 2) AS INTEGER) < ? AND landmark = ?")) {
            statement.setInt(1, startHour);
            statement.setInt(2, endHour);
            statement.setString(3, landmark.toUpperCase());

            try(ResultSet result = statement.executeQuery()){
                while(result.next()){
                    Long id = result.getLong("id");
                    String transportComapanyName = result.getString("transportCompanyName");
                    LocalDateTime departureTime = LocalDateTime.parse(result.getString("departureTime"), DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
                    Float price = result.getFloat("price");
                    int availableSeats = result.getInt("availableSeats");

                    Trip trip = new Trip(landmark, transportComapanyName, departureTime, price, availableSeats);
                    trip.setId(id);

                    trips.add(trip);
                }
            }

        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }

        logger.traceExit(trips);
        return trips;
    }


    @Override
    public Iterable<Trip> findAll() {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        List<Trip> trips = new ArrayList<>();

        try(PreparedStatement statement = connection.prepareStatement("SELECT * FROM Trips")) {
            try(ResultSet result = statement.executeQuery()){
                while(result.next()){
                    Long id = result.getLong("id");
                    String landmark = result.getString("landmark");
                    String transportComapanyName = result.getString("transportCompanyName");
                    LocalDateTime departureTime = LocalDateTime.parse(result.getString("departureTime"), DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
                    Float price = result.getFloat("price");
                    int availableSeats = result.getInt("availableSeats");

                    Trip trip = new Trip(landmark, transportComapanyName, departureTime, price, availableSeats);
                    trip.setId(id);

                    trips.add(trip);
                }
            }

        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }

        logger.traceExit(trips);
        return trips;
    }

    @Override
    public Optional<Trip> save(Trip entity) {
        logger.traceEntry("Saving trip {}", entity);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement statement = connection.prepareStatement("INSERT INTO trips(landmark, transportCompanyName, departureTime, price, availableSeats) VALUES (?, ?, ?, ?, ?)", Statement.RETURN_GENERATED_KEYS)) {
            statement.setString(1, entity.getLandmark().toUpperCase());
            statement.setString(2, entity.getTransportCompanyName());

            String formattedDateTime = entity.getDepartureTime().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            statement.setString(3, formattedDateTime);

            statement.setFloat(4, entity.getPrice());
            statement.setInt(5, entity.getAvailableSeats());

            int affectedRows = statement.executeUpdate();

            if(affectedRows != 0) {
                try (PreparedStatement id_statement = connection.prepareStatement("SELECT last_insert_rowid()")) {
                    try (ResultSet generatedKeys = id_statement.executeQuery()) {
                        if (generatedKeys.next()) {
                            entity.setId(generatedKeys.getLong(1));
                        } else {
                            throw new SQLException("Creating trip failed, no ID obtained.");
                        }
                    }
                }

                logger.trace("Saved {} instances", affectedRows);
                return Optional.of(entity);
            }

        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }

        logger.traceExit();
        return Optional.empty();
    }

    @Override
    public Optional<Trip> update(Long id, Trip entity) {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();

        try(PreparedStatement statement = connection.prepareStatement("UPDATE Trips SET landmark = ?, transportCompanyName = ?, departureTime = ?, price = ?, availableSeats = ? WHERE id = ?")){
            statement.setString(1, entity.getLandmark());
            statement.setString(2, entity.getTransportCompanyName());

            String formattedDateTime = entity.getDepartureTime().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            statement.setString(3, formattedDateTime);

            statement.setFloat(4, entity.getPrice());
            statement.setInt(5, entity.getAvailableSeats());
            statement.setLong(6, id);

            int affectedRows = statement.executeUpdate();
            if(affectedRows == 0) {
                return Optional.of(entity);
            }

            logger.trace("Updated 1 instance");
            return Optional.empty();

        } catch (SQLException e) {
            logger.traceExit();
            System.err.println("Error DB: " + e);
        }

        logger.traceExit();
        return Optional.of(entity);
    }

    @Override
    public Optional<Trip> delete(Long id) {
        Connection connection = dbUtils.getConnection();

        try(PreparedStatement statement = connection.prepareStatement("DELETE FROM Trips WHERE id = ?")){
            statement.setLong(1, id);

            int affectedRows = statement.executeUpdate();
            if(affectedRows == 0) {
                Trip trip = new Trip();
                trip.setId(id);
                return Optional.of(trip);
            }

        } catch (SQLException e) {
            System.err.println("Error DB: " + e);
        }

        return Optional.empty();
    }
}
