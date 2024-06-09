package start;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Primary;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

@ComponentScan("travelAgency")
@SpringBootApplication
public class StartRestServices {
    public static void main(String[] args) {
        SpringApplication.run(StartRestServices.class, args);
    }

    @Bean(name = "properties")
    @Primary
    public Properties getBdProperties() {
        Properties properties = new Properties();

        try {
            System.out.println("Searching for bd.properties in directory " + ((new File(".")).getAbsolutePath()));
            properties.load(new FileReader("C:/MPP Lab/Agentie_turism/RESTservices/src/main/resources/bd.properties"));
        } catch (IOException e) {
            System.err.println("Configuration file bd.properties not found " + e);
        }

        return properties;
    }
}
