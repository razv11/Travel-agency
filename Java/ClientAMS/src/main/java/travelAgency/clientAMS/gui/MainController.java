package travelAgency.clientAMS.gui;

import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import servicesAMS.ITravelAgencyServicesAMS;
import servicesAMS.NotificationSubscriber;
import travelAgency.clientAMS.ams.NotificationReceiverImpl;
import travelAgency.model.Reservation;
import travelAgency.model.Trip;
import travelAgency.model.User;
import travelAgency.notification.Notification;
import travelAgency.services.ITravelAgencyObserver;
import travelAgency.services.TravelAgencyException;

import java.io.IOException;
import java.net.URL;
import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;
import java.util.ResourceBundle;
import java.util.stream.IntStream;


public class MainController implements Initializable, NotificationSubscriber {
    private NotificationReceiverImpl receiver;
    private ITravelAgencyServicesAMS server;
    private User currentUser;
    @FXML
    public Label usernameLabel;

    // Trips table and columns
    @FXML
    public TableView<Trip> tripsTableView;
    @FXML
    public TableColumn<Trip, String> landmarkColumn;
    @FXML
    public TableColumn<Trip, String> transportCompanyNameColumn;
    @FXML
    public TableColumn<Trip, LocalDateTime> departureTimeColumn;
    @FXML
    public TableColumn<Trip, Float> priceColumn;
    @FXML
    public TableColumn<Trip, Integer> seatsColumn;
    @FXML
    ObservableList<Trip> modelTrips = FXCollections.observableArrayList();


    // Search trips table and columns
    @FXML
    public TableView<Trip> searchTableView;
    @FXML
    public TableColumn<Trip, String> transportCompanySearchColumn;
    @FXML
    public TableColumn<Trip, Float> priceSearchColumn;
    @FXML
    public TableColumn<Trip, LocalDateTime> departureTimeSearchColumn;
    @FXML
    public TableColumn<Trip, Integer> seatsSearchColumn;
    @FXML
    ObservableList<Trip> modelSearchTrips = FXCollections.observableArrayList();

    // Text fields and spinner for reservation
    public TextField clientNameField;
    public TextField phoneNumberField;
    public Spinner<Integer> noSeatsSpinner;

    // Text field and ComboBoxes for searching
    public TextField landmarkField;
    public ComboBox<Integer> comboBoxStartTime;
    public ComboBox<Integer> comboBoxEndTime;

    public MainController() {
        System.out.println("Contructor MainController");
    }

    public void setServer(ITravelAgencyServicesAMS server) { this.server = server; }

    public void setNotificationReceiver(NotificationReceiverImpl notificationReceiver) {
        this.receiver = notificationReceiver;
    }

    public void startReceiver() { this.receiver.start(this); }

    public void setUser(User user) {
        this.currentUser = user;
        usernameLabel.setText("Welcome, " + currentUser.getUsername());
    }

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        System.out.println("Initialize window");

        // Initialize columns and model for all trips table
        landmarkColumn.setCellValueFactory(new PropertyValueFactory<>("landmark"));
        transportCompanyNameColumn.setCellValueFactory(new PropertyValueFactory<>("transportCompanyName"));
        departureTimeColumn.setCellValueFactory(new PropertyValueFactory<>("departureTime"));
        priceColumn.setCellValueFactory(new PropertyValueFactory<>("price"));
        seatsColumn.setCellValueFactory(new PropertyValueFactory<>("availableSeats"));
        tripsTableView.setItems(modelTrips);
        tripsTableView.getSelectionModel().setSelectionMode(SelectionMode.SINGLE);

        tripsTableView.setRowFactory(tableView -> new TableRow<Trip>() {
            @Override
            protected void updateItem(Trip item, boolean empty) {
                super.updateItem(item, empty);
                if (item == null || empty) {
                    setStyle(""); // Reset row style
                } else {
                    // Set row style based on available seats
                    if (item.getAvailableSeats() == 0) {
                        setStyle("-fx-background-color: red;");
                    } else {
                        setStyle(""); // Reset row style
                    }
                }
            }
        });

        // Initalize columns and model for search trips table
        transportCompanySearchColumn.setCellValueFactory(new PropertyValueFactory<>("transportCompanyName"));
        priceSearchColumn.setCellValueFactory(new PropertyValueFactory<>("price"));
        departureTimeSearchColumn.setCellValueFactory(new PropertyValueFactory<>("departureTime"));
        seatsSearchColumn.setCellValueFactory(new PropertyValueFactory<>("availableSeats"));
        searchTableView.setItems(modelSearchTrips);
        searchTableView.getSelectionModel().setSelectionMode(SelectionMode.SINGLE);

        searchTableView.setRowFactory(tableView -> new TableRow<Trip>() {
            @Override
            protected void updateItem(Trip item, boolean empty) {
                super.updateItem(item, empty);
                if (item == null || empty) {
                    setStyle(""); // Reset row style
                } else {
                    // Set row style based on available seats
                    if (item.getAvailableSeats() == 0) {
                        setStyle("-fx-background-color: red;");
                    } else {
                        setStyle(""); // Reset row style
                    }
                }
            }
        });

        // Populate the ComboBoxes with values from 1 to 23
        IntStream.rangeClosed(1, 23).forEach(comboBoxStartTime.getItems()::add);
        IntStream.rangeClosed(1, 23).forEach(comboBoxEndTime.getItems()::add);

        // Initialize spinner for number of seats
        SpinnerValueFactory.IntegerSpinnerValueFactory valueFactory = new SpinnerValueFactory.IntegerSpinnerValueFactory(1, 500, 1);
        noSeatsSpinner.setValueFactory(valueFactory);
    }

    public void onPressSearch(ActionEvent actionEvent) {
        String landmark = landmarkField.getText();

        if(landmark.isEmpty()) {
            MessageAlert.showErrorMessage(null, "Insert landmark!");
            return;
        }

        if(comboBoxStartTime.getItems().isEmpty() || comboBoxEndTime.getItems().isEmpty()){
            MessageAlert.showErrorMessage(null, "Select start & end time!");
            return;
        }

        int startHour = comboBoxStartTime.getValue();
        int endHour= comboBoxEndTime.getValue();

        try {
            Trip[] searchedTrips = server.getSearchedTrips(landmark, startHour, endHour);

            if(searchedTrips.length == 0) {
                MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Info", "There are no trips with chosen filter!");
                return;
            }

            List<Trip> searchedTripsList = Arrays.stream(searchedTrips).toList();
            modelSearchTrips.setAll(searchedTripsList);

        } catch (TravelAgencyException e) {
            e.printStackTrace();
        }
    }

    public void onPressReserve(ActionEvent actionEvent) {
        String clientName = clientNameField.getText();
        if(clientName.isEmpty()) {
            MessageAlert.showErrorMessage(null, "Insert client name!");
            return;
        }

        String phoneNumber = phoneNumberField.getText();
        if(phoneNumber.isEmpty()) {
            MessageAlert.showErrorMessage(null, "Insert phone number!");
            return;
        }

        Long number;
        try {
            number = Long.parseLong(phoneNumber);
        }
        catch (IllegalArgumentException exception) {
            MessageAlert.showErrorMessage(null, "Phone number must contain only digits!");
            return;
        }

        int noSeats = noSeatsSpinner.getValue();
        if(tripsTableView.getSelectionModel().isEmpty()) {
            MessageAlert.showErrorMessage(null, "Select a trip!");
            return;
        }

        Trip selectedTrip = tripsTableView.getSelectionModel().getSelectedItem();
        if(noSeats > selectedTrip.getAvailableSeats()) {
            MessageAlert.showErrorMessage(null, "Insufficient number of seats available!");
            return;
        }

        Alert alert = new Alert(Alert.AlertType.CONFIRMATION);
        alert.setTitle("Book confirmation");
        alert.setHeaderText("Are you sure you want to proceed?");
        alert.setContentText("Click OK to confirm or Cancel to cancel.");
        Optional<ButtonType> result = alert.showAndWait();
        if (result.isPresent() && result.get() == ButtonType.OK) {
            Reservation reservation = new Reservation(clientName, number, noSeats, currentUser, selectedTrip);
            try {
                server.reserveTrip(reservation);
            } catch (TravelAgencyException e) {
                MessageAlert.showErrorMessage(null, e.getMessage());
                return;
            }

            MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Succesfully booked trip", "Thank you!");
            clientNameField.clear();
            phoneNumberField.clear();
            noSeatsSpinner.getValueFactory().setValue(1);
        }
    }

    public void setTrips() {
        try {
            Trip[] trips = server.getTrips();

            List<Trip> tripList = Arrays.stream(trips).toList();
            modelTrips.setAll(tripList);

        } catch (TravelAgencyException e) {
            e.printStackTrace();
        }
    }

    public void logout() {
        try {
            server.logout(currentUser);
            this.receiver.stop();
        } catch (TravelAgencyException e) {
            System.out.println("Logout error " + e);
        }
    }

    public void onPressLogout(ActionEvent actionEvent) throws IOException {
        logout();
        ((Node)(actionEvent.getSource())).getScene().getWindow().hide();
    }

    @Override
    public void notificationReceived(Notification notification) {
        System.out.println("\nUpdating Trip...\n");
        Platform.runLater(() -> {
            for(Trip trip : tripsTableView.getItems()) {
                if (trip.getId() == notification.getTripId()) {
                    int newNumber = trip.getAvailableSeats() - notification.getNuberOfTickets();
                    trip.setAvailableSeats(newNumber);

                    tripsTableView.refresh();
                    break;
                }
            }
            System.out.println("Book reserved");
        });
    }
}
