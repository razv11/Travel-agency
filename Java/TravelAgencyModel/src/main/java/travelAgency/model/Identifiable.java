package travelAgency.model;

import java.io.Serializable;
import java.util.Objects;

public class Identifiable<ID> implements Serializable {
    protected ID id;
    public ID getId() {
        return id;
    }
    public void setId(ID id) {
        this.id = id;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Identifiable)) return false;
        Identifiable<?> identifiable = (Identifiable<?>) o;
        return getId().equals(identifiable.getId());
    }

    @Override
    public int hashCode() {
        return Objects.hash(getId());
    }

    @Override
    public String toString() {
        return "Entity{" +
                "id=" + id +
                '}';
    }
}