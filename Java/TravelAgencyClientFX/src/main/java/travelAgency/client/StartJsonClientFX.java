package travelAgency.client;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import travelAgency.client.gui.LoginController;
import travelAgency.client.gui.MainController;
import travelAgency.network.jsonprotocol.TravelAgencyServicesJsonProxy;
import travelAgency.services.ITravelAgencyServices;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class StartJsonClientFX extends Application {
    private static int defaultTravelAgencyServerPort = 55556;
    private static String defaultServer = "localhost";

    @Override
    public void start(Stage primaryStage) throws Exception {
        System.out.println("In start method");
        String serverIP = defaultServer;
//        Properties clientProps = new Properties();
//
//        try {
//            clientProps.load(StartJsonClientFX.class.getResourceAsStream("travelAgencyClient.properties"));
//            System.out.println("Client properties set");
//            clientProps.list(System.out);
//        } catch (IOException e) {
//            System.err.println("Cannot find travelAgencyClient.properties" + e);
//            return ;
//        }
//
//        String serverIP = clientProps.getProperty("travelAgency.server.host", defaultServer);
        int serverPort = defaultTravelAgencyServerPort;

//        try {
//            serverPort = Integer.parseInt(clientProps.getProperty("travelAgency.server.port"));
//        } catch (NumberFormatException e) {
//             System.err.println("Wrong port number: " + e.getMessage());
//            System.out.println("Using server port: " + defaultTravelAgencyServerPort);
//        }

        // Login window
        System.out.println("Using server IP: " + serverIP);
        System.out.println("Using server port: " + serverPort);

        ITravelAgencyServices server = new TravelAgencyServicesJsonProxy(serverIP, serverPort);

        FXMLLoader loginLoader = new FXMLLoader(getClass().getResource("/view/login.fxml"));
        Parent root = loginLoader.load();

        LoginController loginCtrl = loginLoader.getController();
        loginCtrl.setServer(server);


        // Main window
        FXMLLoader mainWindow = new FXMLLoader(getClass().getResource("/view/main.fxml"));
        Parent mainRoot = mainWindow.load();

        MainController mainCtrl = mainWindow.getController();
        mainCtrl.setService(server);

        loginCtrl.setMainController(mainCtrl);
        loginCtrl.setParent(mainRoot);

        primaryStage.setTitle("Travel agency");
        primaryStage.setScene(new Scene(root, 570, 400));
        primaryStage.show();
    }
}
