package ro.ubbcluj.mpp.repository;

import ro.ubbcluj.mpp.domain.Entity;

import javax.swing.text.html.Option;
import java.util.Optional;

public interface Repository<ID, E extends Entity<ID>> {
    Iterable<E> findAll();
    Optional<E> save(E entity);
    Optional<E> update(E entity);
}
