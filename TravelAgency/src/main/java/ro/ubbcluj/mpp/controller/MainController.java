package ro.ubbcluj.mpp.controller;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.Pane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import ro.ubbcluj.mpp.domain.MessageAlert;
import ro.ubbcluj.mpp.domain.Reservation;
import ro.ubbcluj.mpp.domain.Trip;
import ro.ubbcluj.mpp.domain.User;
import ro.ubbcluj.mpp.repository.userRepo.UsersDBRepository;
import ro.ubbcluj.mpp.service.ReservationService;
import ro.ubbcluj.mpp.service.TripService;
import ro.ubbcluj.mpp.service.UserService;

import java.io.IOException;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;
import java.util.stream.IntStream;
import java.util.stream.StreamSupport;

public class MainController {
    private TripService tripService;
    private ReservationService reservationService;
    private User currentUser;
    @FXML
    private Stage mainStage;
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

    public void setAttributes(Stage mainStg, User currUser, TripService tripServ, ReservationService reservationServ){
        this.mainStage = mainStg;
        this.currentUser = currUser;
        this.tripService = tripServ;
        this.reservationService = reservationServ;

        usernameLabel.setText("Welcome, " + currentUser.getUsername());
        initModelForAllTrips();
    }

    @FXML
    void initialize(){
        // Initialize columns and model for all trips table
        landmarkColumn.setCellValueFactory(new PropertyValueFactory<>("landmark"));
        transportCompanyNameColumn.setCellValueFactory(new PropertyValueFactory<>("transportCompanyName"));
        departureTimeColumn.setCellValueFactory(new PropertyValueFactory<>("departureTime"));
        priceColumn.setCellValueFactory(new PropertyValueFactory<>("price"));
        seatsColumn.setCellValueFactory(new PropertyValueFactory<>("availableSeats"));
        tripsTableView.setItems(modelTrips);
        tripsTableView.getSelectionModel().setSelectionMode(SelectionMode.SINGLE);

        // Initalize columns and model for search trips table
        transportCompanySearchColumn.setCellValueFactory(new PropertyValueFactory<>("transportCompanyName"));
        priceSearchColumn.setCellValueFactory(new PropertyValueFactory<>("price"));
        departureTimeSearchColumn.setCellValueFactory(new PropertyValueFactory<>("departureTime"));
        seatsSearchColumn.setCellValueFactory(new PropertyValueFactory<>("availableSeats"));
        searchTableView.setItems(modelSearchTrips);
        searchTableView.getSelectionModel().setSelectionMode(SelectionMode.SINGLE);

        // Populate the ComboBoxes with values from 1 to 23
        IntStream.rangeClosed(1, 23).forEach(comboBoxStartTime.getItems()::add);
        IntStream.rangeClosed(1, 23).forEach(comboBoxEndTime.getItems()::add);

        // Initialize spinner for number of seats
        SpinnerValueFactory.IntegerSpinnerValueFactory valueFactory = new SpinnerValueFactory.IntegerSpinnerValueFactory(1, 500, 1);
        noSeatsSpinner.setValueFactory(valueFactory);
    }

    private void initModelForAllTrips(){
        List<Trip> trips = StreamSupport.stream(tripService.findAll().spliterator(), false).toList();
        modelTrips.setAll(trips);
    }

    private void initModelForSearchTrips(Iterable<Trip> tripsIterable) {
        List<Trip> trips = StreamSupport.stream(tripsIterable.spliterator(), false).toList();
        modelSearchTrips.setAll(trips);
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

        initModelForSearchTrips(tripService.findTripsBetweenHoursHavingLandmark(startHour, endHour, landmark));
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
            Optional<Trip> updatedTrip = tripService.updateNumberOfSeats(selectedTrip, noSeats);
            if(updatedTrip.isPresent()) {
                MessageAlert.showErrorMessage(null, "Error while trying to update trip!\nReservation was aborted.\nPlease try again.");
                return;
            }

            Optional<Reservation> reservation = reservationService.save(clientName, number, noSeats, currentUser.getId(), selectedTrip.getId());
            if (reservation.isPresent()) {
                MessageAlert.showErrorMessage(null, "Error while trying to save this reservation!\nReservation was aborted.\nPlease try again.");
                return;
            }

            MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Succesfully booked trip", "Thank you!");
            initModelForAllTrips();
            clientNameField.clear();
            phoneNumberField.clear();
            noSeatsSpinner.getValueFactory().setValue(1);
        }
    }

    public void onPressLogout(ActionEvent actionEvent) throws IOException {
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/view/login.fxml"));
        Pane primaryPane = loader.load();

        Scene primaryScene = new Scene(primaryPane);
        Stage newStage = new Stage();
        newStage.setScene(primaryScene);
        newStage.setTitle("Login");

        LoginController ctrl = loader.getController();
        ctrl.setAttributes(newStage, getUserService());

        mainStage.close();
        newStage.show();
    }

    private UserService getUserService() {
        UsersDBRepository usersDBRepository = new UsersDBRepository(System.getProperties());
        return new UserService(usersDBRepository);
    }
}
