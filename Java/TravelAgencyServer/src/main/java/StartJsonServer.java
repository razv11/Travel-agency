import travelAgency.network.utils.AbstractServer;
import travelAgency.network.utils.ServerException;
import travelAgency.network.utils.TravelAgencyJsonConcurrentServer;
import travelAgency.persistence.ReservationRepository;
import travelAgency.persistence.TripRepository;
import travelAgency.persistence.UserRepository;
import travelAgency.persistence.repository.jdbc.ReservationsDBRepository;
import travelAgency.persistence.repository.jdbc.TripsDBRepository;
import travelAgency.persistence.repository.jdbc.UsersDBRepository;
import travelAgency.server.TravelAgencyServicesImplementation;
import travelAgency.services.ITravelAgencyServices;

import java.io.IOException;
import java.util.Properties;

public class StartJsonServer {
    private static int defaultPort = 55555;

    public static void main(String[] args) {

        Properties serverProps = new Properties();
        try {
            serverProps.load(StartJsonServer.class.getResourceAsStream("travelAgencyServer.properties"));
            System.out.println("Server properties set");
            serverProps.list(System.out);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        UserRepository userRepository = new UsersDBRepository(serverProps);
        TripRepository tripRepository = new TripsDBRepository(serverProps);
        ReservationRepository reservationRepository = new ReservationsDBRepository(serverProps);

        ITravelAgencyServices travelAgencyServices = new TravelAgencyServicesImplementation(userRepository, tripRepository, reservationRepository);

        int travelAgencyServerPort = defaultPort;
        try {
            travelAgencyServerPort = Integer.parseInt(serverProps.getProperty("travelagency.server.port"));
        } catch (NumberFormatException e) {
            System.err.println("Wrong port number: " + e.getMessage());
            System.err.println("Using default port: " + defaultPort);
        }

        System.out.println("The server is starting using port: "  + travelAgencyServerPort);

        AbstractServer server = new TravelAgencyJsonConcurrentServer(travelAgencyServerPort, travelAgencyServices);

        try {
            server.start();
        } catch (ServerException e) {
            System.err.println("Error when trying to start server");
        }
    }
}
