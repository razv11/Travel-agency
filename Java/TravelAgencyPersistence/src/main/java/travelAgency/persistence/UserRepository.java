package travelAgency.persistence;

import travelAgency.model.User;

import java.util.Optional;

public interface UserRepository extends Repository<Long, User> {
    Optional<User> findUserByUsername(String username);
}
