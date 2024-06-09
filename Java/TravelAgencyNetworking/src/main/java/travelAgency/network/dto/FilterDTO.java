package travelAgency.network.dto;

import java.io.Serializable;

public class FilterDTO implements Serializable {
    String landmark;
    int startHour;
    int endHour;
    public FilterDTO(String landmark, int startHour, int endHour) {
        this.landmark = landmark;
        this.startHour = startHour;
        this.endHour = endHour;
    }

    public String getLandmark() {
        return landmark;
    }

    public void setLandmark(String landmark) {
        this.landmark = landmark;
    }

    public int getStartHour() {
        return startHour;
    }

    public void setStartHour(int startHour) {
        this.startHour = startHour;
    }

    public int getEndHour() {
        return endHour;
    }

    public void setEndHour(int endHour) {
        this.endHour = endHour;
    }

    @Override
    public String toString() {
        return "FilterDTO{" +
                "landmark='" + landmark + '\'' +
                ", startHour=" + startHour +
                ", endHour=" + endHour +
                '}';
    }
}
