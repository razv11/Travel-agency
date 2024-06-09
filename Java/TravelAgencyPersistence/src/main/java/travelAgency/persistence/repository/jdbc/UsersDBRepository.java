package travelAgency.persistence.repository.jdbc;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import travelAgency.persistence.UserRepository;
import travelAgency.model.User;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Optional;
import java.util.Properties;

public class UsersDBRepository implements UserRepository {
    private JdbcUtils dbUtils;
    private static final Logger logger = LogManager.getLogger();

    public UsersDBRepository(Properties prop) {
        logger.info("Initializing UsersDBRepository with properties {} ", prop);
        dbUtils = new JdbcUtils(prop);
    }
    @Override
    public Iterable<User> findAll() {
        return null;
    }

    @Override
    public Optional<User> save(User entity) {
        logger.traceEntry("Saving user {}", entity);
        Connection connection = dbUtils.getConnection();

        try(PreparedStatement statement = connection.prepareStatement("INSERT INTO Users(username, password) VALUES (?, ?)")) {
            statement.setString(1, entity.getUsername());
            statement.setString(2, entity.getPassword());

            int affectedRows = statement.executeUpdate();
            if(affectedRows != 0) {
                logger.traceExit();
                return Optional.empty();
            }

        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        logger.traceExit();
        return Optional.empty();
    }

    @Override
    public Optional<User> update(Long id, User entity) {
        return Optional.empty();
    }

    @Override
    public Optional<User> findUserByUsername(String username){
        logger.traceEntry("Username {}", username);
        Connection connection = dbUtils.getConnection();

        try(PreparedStatement statement = connection.prepareStatement("SELECT * FROM Users WHERE username=?")) {
            statement.setString(1, username);

            try(ResultSet result = statement.executeQuery()){
                while(result.next()){
                    Long id = result.getLong("id");
                    String password = result.getString("password");

                    User user = new User(username, password);
                    user.setId(id);

                    logger.traceExit();
                    return Optional.of(user);
                }
            }

        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        logger.traceExit();
        return Optional.empty();
    }
}
