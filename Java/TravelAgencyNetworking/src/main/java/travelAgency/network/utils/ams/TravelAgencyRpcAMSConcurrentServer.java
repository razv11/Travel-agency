package travelAgency.network.utils.ams;

import servicesAMS.ITravelAgencyServicesAMS;
import travelAgency.network.jsonprotocol.ams.TravelAgencyServerAMSRpcReflectionWorker;
import travelAgency.network.utils.AbstractConcurrentServer;

import java.net.Socket;

public class TravelAgencyRpcAMSConcurrentServer extends AbstractConcurrentServer {
    private ITravelAgencyServicesAMS server;

    public TravelAgencyRpcAMSConcurrentServer(String port, ITravelAgencyServicesAMS server) {
        super(Integer.parseInt(port));
        this.server = server;
        System.out.println("TravelAgencyRpcAMSConcurrentServer started on port " + port);
    }

    @Override
    protected Thread createWorker(Socket client) {
        TravelAgencyServerAMSRpcReflectionWorker worker = new TravelAgencyServerAMSRpcReflectionWorker(server, client);

        return new Thread(worker);
    }
}
