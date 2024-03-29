package ro.ubbcluj.mpp;

import ro.ubbcluj.mpp.domain.Reservation;
import ro.ubbcluj.mpp.domain.Trip;
import ro.ubbcluj.mpp.domain.User;
import ro.ubbcluj.mpp.repository.reservationRepo.ReservationsDBRepository;
import ro.ubbcluj.mpp.repository.tripRepo.TripsDBRepository;
import ro.ubbcluj.mpp.repository.userRepo.UsersDBRepository;

import java.io.FileReader;
import java.io.IOException;
import java.time.LocalDateTime;
import java.util.Properties;


public class Main {
    public static void main(String[] args) {
        Properties props=new Properties();
        try {
            props.load(new FileReader("bd.config"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }

        TripsDBRepository tripsDBRepository = new TripsDBRepository(props);
        tripsDBRepository.save(new Trip("Paris", "Wizzair", LocalDateTime.of(2024, 4, 15, 12, 0), Float.valueOf(250), 200));
        tripsDBRepository.save(new Trip("Roma", "BlueAir", LocalDateTime.of(2024, 5, 20, 13, 15), Float.valueOf(330), 250));
        tripsDBRepository.save(new Trip("Paris", "Wizzair", LocalDateTime.of(2024, 4, 20, 13, 35), Float.valueOf(250), 100));
        tripsDBRepository.save(new Trip("Paris", "Tarom", LocalDateTime.of(2024, 4, 22, 15, 50), Float.valueOf(360), 80));

        System.out.println("\n\nFind by landmark (Paris):");
        for(Trip trip : tripsDBRepository.findByLandmark("Paris")){
            System.out.println(trip);
        }

        UsersDBRepository usersDBRepository = new UsersDBRepository(props);
        usersDBRepository.save(new User("razvan", "password"));

        ReservationsDBRepository reservationsDBRepository = new ReservationsDBRepository(props);
        reservationsDBRepository.save(new Reservation("Dorel", 1234L, 2, 1L, 1L));
        reservationsDBRepository.save(new Reservation("Marius", 5678L, 4, 1L, 2L));
        reservationsDBRepository.save(new Reservation("Ioana", 1256L, 5, 1L, 3L));

        System.out.println("\n\nReservations:");
        for(Reservation reservation : reservationsDBRepository.findAll()){
            System.out.println(reservation);
        }

        System.out.println("\n\n");
    }
}