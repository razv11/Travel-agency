package travelAgency.model;

import jakarta.persistence.*;

@Entity
@Table (name = "users")
public class User extends Identifiable<Long> {
    @Id
    @GeneratedValue (generator = "increment")
    private Long uId;
    @Column (name = "username")
    private String username;
    @Column (name = "password")
    private String password;

    public User() { }
    public User(String username, String password) {
        this.username = username;
        this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public Long getId() {
        return id;
    }

    @Override
    public void setId(Long uId) {
        this.id = uId;
    }
}
