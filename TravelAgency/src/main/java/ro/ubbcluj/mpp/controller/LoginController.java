package ro.ubbcluj.mpp.controller;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;
import ro.ubbcluj.mpp.domain.MessageAlert;
import ro.ubbcluj.mpp.domain.User;
import ro.ubbcluj.mpp.repository.reservationRepo.ReservationsDBRepository;
import ro.ubbcluj.mpp.repository.tripRepo.TripsDBRepository;
import ro.ubbcluj.mpp.service.ReservationService;
import ro.ubbcluj.mpp.service.TripService;
import ro.ubbcluj.mpp.service.UserService;

import javafx.scene.control.TextField;

import java.io.IOException;
import java.time.LocalDateTime;
import java.util.Optional;

public class LoginController {
    @FXML
    private Stage primaryStage;
    @FXML
    public TextField usernameField;
    @FXML
    public TextField passwordField;

    private UserService userService;
    public void setAttributes(Stage primaryStg, UserService userServ) {
        this.primaryStage = primaryStg;
        this.userService = userServ;
    }

    public void onPressLogin(ActionEvent actionEvent) throws IOException {
        String username = usernameField.getText();
        String password = passwordField.getText();

        if(username.isEmpty() || password.isEmpty()){
            MessageAlert.showErrorMessage(null, "Username or password is empty!");
            return;
        }

        if(!userService.checkPassword(username, password)){
            MessageAlert.showErrorMessage(null, "Invalid username or password!");
            return;
        }

        Optional<User> loggedUser = userService.findUserByUsername(username);
        if(loggedUser.isEmpty()) {
            MessageAlert.showErrorMessage(null, "User not found!");
            return;
        }

        FXMLLoader loader = new FXMLLoader(getClass().getResource("/view/main.fxml"));
        Pane mainPane = loader.load();

        MainController mainController = loader.getController();
        mainController.setAttributes(primaryStage, loggedUser.get(), getTripService(), getReservationService());
        Scene mainScene = new Scene(mainPane);
        primaryStage.setTitle("Travel agency");
        primaryStage.setScene(mainScene);

        // Clean up login scene resources
        usernameField.setText(""); // Clear text fields
        passwordField.setText("");
        usernameField.setOnAction(null); // Remove event listener
        passwordField.setOnAction(null);
    }

    private TripService getTripService() {
        TripsDBRepository tripsDBRepository = new TripsDBRepository(System.getProperties());
        return new TripService(tripsDBRepository);
    }

    private ReservationService getReservationService() {
        ReservationsDBRepository reservationsDBRepository = new ReservationsDBRepository(System.getProperties());
        return new ReservationService(reservationsDBRepository);
    }


    public void onPressCancel(ActionEvent actionEvent) {
        primaryStage.close();
    }
}
