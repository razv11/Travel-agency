package ro.ubbcluj.mpp;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;
import ro.ubbcluj.mpp.controller.LoginController;
import ro.ubbcluj.mpp.repository.userRepo.UsersDBRepository;
import ro.ubbcluj.mpp.service.UserService;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class FXMain extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception {
        primaryStage.setTitle("Login");

        FXMLLoader loader = new FXMLLoader(getClass().getResource("/view/login.fxml"));
        Pane primaryPane =(Pane)loader.load();
        LoginController ctrl = loader.getController();
        ctrl.setAttributes(primaryStage, getUserService());

        Scene primaryScene = new Scene(primaryPane);
        primaryStage.setScene(primaryScene);

        primaryStage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }

    private UserService getUserService(){
        Properties serverProps = new Properties(System.getProperties());
        try {
            serverProps.load(new FileReader("bd.config"));
            System.setProperties(serverProps);
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }

        UsersDBRepository usersDBRepository = new UsersDBRepository(serverProps);
        UserService userService = new UserService(usersDBRepository);
        //userService.save("razvan", "qwerty");

        return userService;
    }
}
