package travelAgency.clientAMS.gui;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import servicesAMS.ITravelAgencyServicesAMS;
import travelAgency.model.User;
import travelAgency.services.TravelAgencyException;

public class LoginController {
    private ITravelAgencyServicesAMS server;
    private MainController mainController;
    private User crtUser;
    @FXML
    public TextField usernameField;
    @FXML
    public TextField passwordField;
    Parent mainTravelAgencyParent;

    public void setServer(ITravelAgencyServicesAMS server) { this.server = server; }

    public void setParent(Parent p) {
        this.mainTravelAgencyParent = p;
    }

    public void setMainController(MainController ctrl) { this.mainController = ctrl; }

    public void onPressLogin(ActionEvent actionEvent) {
        String username = usernameField.getText();
        String password = passwordField.getText();

        if(username.isEmpty() || password.isEmpty()){
            MessageAlert.showErrorMessage(null, "Username or password is empty!");
            return;
        }

        crtUser = new User(username, password);

        try {
            server.login(crtUser);

            Stage stage = new Stage();
            stage.setTitle("Travel agency");
            stage.setScene(new Scene(mainTravelAgencyParent));

            stage.setOnCloseRequest(windowEvent -> {
                mainController.logout();
                System.exit(0);
            });

            stage.show();
            mainController.startReceiver();
            mainController.setUser(crtUser);
            mainController.setTrips();
            ((Node) (actionEvent.getSource())).getScene().getWindow().hide();

        } catch (TravelAgencyException e) {
            MessageAlert.showErrorMessage(null, e.getMessage());

            usernameField.setText("");
            passwordField.setText("");
        }
    }

    public void onPressCancel(ActionEvent actionEvent) {
        System.exit(0);
    }
}
