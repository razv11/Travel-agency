package ro.ubbcluj.mpp.service;

import ro.ubbcluj.mpp.domain.User;
import ro.ubbcluj.mpp.repository.userRepo.UsersDBRepository;

import java.util.Optional;

import at.favre.lib.crypto.bcrypt.BCrypt;
public class UserService {
    private final UsersDBRepository repo;

    public UserService(UsersDBRepository repo) {
        this.repo = repo;
    }

    private String hashPassword(String password) {
        // Hash a password
        return BCrypt.withDefaults().hashToString(12, password.toCharArray());
    }

    public boolean checkPassword(String candidateUsername, String candidatePassword) {
        Optional<User> user = repo.findUserByUsername(candidateUsername);

        if(user.isEmpty()){
            return false;
        }

        String hashedPassword = user.get().getPassword();

        // Check if a password matches the hashed password
        return BCrypt.verifyer().verify(candidatePassword.toCharArray(), hashedPassword).verified;
    }

    public void save(String username, String password) {
        User newUser = new User(username, hashPassword(password));
        repo.save(newUser);
    }

    public Optional<User> findUserByUsername(String username) {
        return repo.findUserByUsername(username);
    }
}
