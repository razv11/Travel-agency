package ro.ubbcluj.mpp.repository.reservationRepo;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import ro.ubbcluj.mpp.domain.Reservation;
import ro.ubbcluj.mpp.repository.JdbcUtils;
import ro.ubbcluj.mpp.repository.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Properties;

public class ReservationsDBRepository implements ReservationRepository {
    private JdbcUtils dbUtils;
    private static final Logger logger = LogManager.getLogger();

    public ReservationsDBRepository(Properties prop) {
        logger.info("Initializing ReservationsDBRepository with properties {} ", prop);
        dbUtils = new JdbcUtils(prop);
    }

    @Override
    public Iterable<Reservation> findAll() {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        List<Reservation> reservations = new ArrayList<>();

        try(PreparedStatement statement = connection.prepareStatement("SELECT * FROM Reservations")) {
            try(ResultSet result = statement.executeQuery()) {

                while(result.next()) {
                    Long id = result.getLong("id");
                    String clientName = result.getString("clientName");
                    Long phoneNumber = result.getLong("phoneNumber");
                    int numberOfTickets = result.getInt("numberOfTickets");
                    Long tripId = result.getLong("tripId");
                    Long userId = result.getLong("userId");

                    Reservation reservation = new Reservation(clientName, phoneNumber, numberOfTickets, userId, tripId);
                    reservation.setId(id);
                    reservations.add(reservation);
                }

            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB: " + e);
        }

        logger.traceExit();
        return reservations;
    }

    @Override
    public Optional<Reservation> save(Reservation entity) {
        logger.traceEntry("Saving reservation {}", entity);
        Connection connection = dbUtils.getConnection();

        try(PreparedStatement statement = connection.prepareStatement("INSERT INTO Reservations(clientName, phoneNumber, numberOfTickets, tripId, userId) VALUES (?, ?, ?, ?, ?)")) {
            statement.setString(1, entity.getClientName());
            statement.setLong(2, entity.getPhoneNumber());
            statement.setInt(3, entity.getNumberOfTickets());
            statement.setLong(4, entity.getTripId());
            statement.setLong(5, entity.getAgencyUserId());

            int affectedRows = statement.executeUpdate();

            if(affectedRows != 0) {
                logger.traceExit();
                return Optional.empty();
            }

        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB: " + e);
        }

        logger.traceExit();
        return Optional.of(entity);
    }

    @Override
    public Optional<Reservation> update(Reservation entity) {
        return Optional.empty();
    }
}
