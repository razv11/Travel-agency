package travelAgency.clientAMS;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import org.apache.xbean.spring.context.ClassPathXmlApplicationContext;
import servicesAMS.ITravelAgencyServicesAMS;
import travelAgency.clientAMS.ams.NotificationReceiverImpl;
import travelAgency.clientAMS.gui.LoginController;
import travelAgency.clientAMS.gui.MainController;
import travelAgency.network.jsonprotocol.ams.TravelAgencyServerAMSRpcProxy;

public class StartClientAMS extends Application {
    @Override
    public void start(Stage primaryStage) throws Exception {
        ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext("spring-client.xml");
        ITravelAgencyServicesAMS servicesAMS = context.getBean("travelAgencyServices", TravelAgencyServerAMSRpcProxy.class);
        NotificationReceiverImpl notificationReceiver = context.getBean("notificationReceiver", NotificationReceiverImpl.class);

        FXMLLoader loginLoader = new FXMLLoader(getClass().getResource("/view/login.fxml"));
        Parent root = loginLoader.load();

        LoginController loginCtrl = loginLoader.getController();
        loginCtrl.setServer(servicesAMS);

        // Main window
        FXMLLoader mainWindow = new FXMLLoader(getClass().getResource("/view/main.fxml"));
        Parent mainRoot = mainWindow.load();

        MainController mainCtrl = mainWindow.getController();
        mainCtrl.setServer(servicesAMS);
        mainCtrl.setNotificationReceiver(notificationReceiver);

        loginCtrl.setMainController(mainCtrl);
        loginCtrl.setParent(mainRoot);

        primaryStage.setTitle("Travel agency");
        primaryStage.setScene(new Scene(root, 480, 320));
        primaryStage.show();
    }
}
