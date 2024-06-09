import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import org.apache.xbean.spring.context.ClassPathXmlApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import travelAgency.network.utils.AbstractConcurrentServer;
import travelAgency.network.utils.AbstractServer;
import travelAgency.network.utils.ServerException;
import travelAgency.network.utils.ams.TravelAgencyRpcAMSConcurrentServer;

public class StartAMSRpcServer {
    public static void main(String[] args) {
        ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext("spring-server.xml");
        AbstractServer server = context.getBean("travelAgencyTCPServer", TravelAgencyRpcAMSConcurrentServer.class);

        try {
            server.start();
        } catch (ServerException e) {
            System.err.println("Error starting the server " + e.getMessage());
        }
    }
}