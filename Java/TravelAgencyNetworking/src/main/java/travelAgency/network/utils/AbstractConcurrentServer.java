package travelAgency.network.utils;

import java.net.Socket;

public abstract class AbstractConcurrentServer extends AbstractServer {

    public AbstractConcurrentServer(int port) {
        super(port);
        System.out.println("Initializing AbstractConcurrentServer");
    }

    @Override
    protected void processRequest(Socket client) {
        Thread newClient = createWorker(client);
        newClient.start();
    }

    protected abstract Thread createWorker(Socket client);
}
