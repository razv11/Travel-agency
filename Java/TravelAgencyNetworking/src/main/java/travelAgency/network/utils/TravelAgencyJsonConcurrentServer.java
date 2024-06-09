package travelAgency.network.utils;

import travelAgency.network.jsonprotocol.TravelAgencyJsonWorker;
import travelAgency.services.ITravelAgencyServices;

import java.net.Socket;

public class TravelAgencyJsonConcurrentServer extends AbstractConcurrentServer {
    private ITravelAgencyServices travelAgencyServer;
    public TravelAgencyJsonConcurrentServer(int port, ITravelAgencyServices serv) {
        super(port);
        this.travelAgencyServer = serv;
        System.out.println("Initializing TravelAgencyJsonConcurrentServer");
    }

    @Override
    protected Thread createWorker(Socket client) {
        TravelAgencyJsonWorker worker = new TravelAgencyJsonWorker(travelAgencyServer, client);

        return new Thread(worker);
    }
}
