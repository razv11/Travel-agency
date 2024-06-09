package travelAgency.persistence.repository.jdbc;

import org.hibernate.Session;
import travelAgency.model.User;
import travelAgency.persistence.HibernateUtils;
import travelAgency.persistence.UserRepository;

import java.util.Optional;
import java.util.concurrent.atomic.AtomicReference;

public class UsersDbHibernateRepository implements UserRepository {

    @Override
    public Iterable<User> findAll() {
        try(Session session = HibernateUtils.getSessionFactory().openSession()) {
            return session.createQuery("from User", User.class).getResultList();
        }
    }

    @Override
    public Optional<User> save(User entity) {
        AtomicReference<Optional<User>> result = new AtomicReference<>(Optional.empty());

        HibernateUtils.getSessionFactory().inTransaction(session -> {
            User user = session.createSelectionQuery("from User where username = :u", User.class)
                    .setParameter("u", entity.getUsername())
                    .uniqueResult();

            if(user == null) {
                session.persist(entity);
                User savedUser = session.createSelectionQuery("from User where username = :u", User.class)
                        .setParameter("u", entity.getUsername())
                        .uniqueResult();

                result.set(Optional.of(savedUser));
            }
        });

        return  result.get();
    }

    @Override
    public Optional<User> update(Long id, User entity) {
        return Optional.empty();
    }

    @Override
    public Optional<User> findUserByUsername(String username) {
        try(Session session = HibernateUtils.getSessionFactory().openSession()) {
            User user = session.createSelectionQuery("from User where username = :u", User.class)
                    .setParameter("u", username)
                    .getSingleResult();

            return user == null ? Optional.empty() : Optional.of(user);
        }
    }
}
