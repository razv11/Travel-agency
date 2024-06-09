package travelAgency.persistence;

import travelAgency.model.Identifiable;

import java.util.Optional;

public interface Repository<ID, E extends Identifiable<ID>> {
    Iterable<E> findAll();
    Optional<E> save(E entity);
    Optional<E> update(ID id, E entity);
}
