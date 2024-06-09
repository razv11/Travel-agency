package travelAgency.network.utils;

import travelAgency.network.protobuffprotocol.ProtoAgencyTravelWorker;
import travelAgency.services.ITravelAgencyServices;

import java.net.Socket;

public class TravelAgencyProtobuffConcurrentServer extends AbstractConcurrentServer{

    private ITravelAgencyServices travelAgencyServer;

    public TravelAgencyProtobuffConcurrentServer(int port, ITravelAgencyServices travelAgencyServer) {
        super(port);
        this.travelAgencyServer = travelAgencyServer;
        System.out.println("Creating TravelAgencyProtobuffConcurrentServer...");
    }

    @Override
    protected Thread createWorker(Socket client) {
        ProtoAgencyTravelWorker worker = new ProtoAgencyTravelWorker(travelAgencyServer, client);
        Thread thread = new Thread(worker);
        return thread;
    }
}
