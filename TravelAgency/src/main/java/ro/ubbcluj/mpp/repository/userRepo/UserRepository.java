package ro.ubbcluj.mpp.repository.userRepo;

import ro.ubbcluj.mpp.repository.Repository;
import ro.ubbcluj.mpp.domain.User;

import java.util.Optional;

public interface UserRepository extends Repository<Long, User> {
    Optional<User> findUserByUsername(String username);
}
