package start;

import org.springframework.web.client.RestClientException;
import rest.client.TripsClient;
import travelAgency.model.Trip;
import travelAgency.clientAMS.ServiceException;

import java.time.LocalDateTime;

public class StartRestClient {
    private static final TripsClient tripsClient = new TripsClient();

    public static void main(String[] args) {
        Trip trip = new Trip("Madrid", "Wizzair", LocalDateTime.of(2024, 10, 16, 20, 15), 319.0f, 185);

        try {
            System.out.println("\nAdding new Trip: " + trip);
            show(() -> System.out.println(tripsClient.create(trip)));

            System.out.println("\n\nPrinting all users:");
            show(() -> {
                Trip[] trips = tripsClient.getAll();
                for(Trip currentTrip : trips) {
                    System.out.println(currentTrip);

                    if(currentTrip.getLandmark().equalsIgnoreCase(trip.getLandmark().toLowerCase())) {
                        trip.setId(currentTrip.getId());
                    }
                }
            });

            trip.setAvailableSeats(500);
            System.out.println("\n\nUpdating Trip (set availableSeats = 500)");
            show(() -> System.out.println(tripsClient.update(trip.getId(), trip)));

            System.out.println("\n\nPrinting all users:");
            show(() -> {
                Trip[] trips = tripsClient.getAll();
                for(Trip currentTrip : trips) {
                    System.out.println(currentTrip);

                    if(currentTrip.getLandmark().equals(trip.getLandmark())) {
                        trip.setId(currentTrip.getId());
                    }
                }
            });

            System.out.println("\n\nDeleting Trip with id: " + trip.getId());
            show(() -> tripsClient.delete(trip.getId()));

            System.out.println("\n\nPrinting all users:");
            show(() -> {
                Trip[] trips = tripsClient.getAll();
                for(Trip currentTrip : trips) {
                    System.out.println(currentTrip);

                    if(currentTrip.getLandmark().equals(trip.getLandmark())) {
                        trip.setId(currentTrip.getId());
                    }
                }
            });

        } catch (RestClientException e) {
            System.out.println("Exception: " + e.getMessage());
        }
    }

    private static void show(Runnable task) {
        try {
            task.run();
        } catch (ServiceException e) {
            System.out.println("Service exception: " + e);
        }
    }
}
