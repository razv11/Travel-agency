package travelAgency.clientAMS.ams;

import org.springframework.jms.core.JmsOperations;
import servicesAMS.NotificationReceiver;
import servicesAMS.NotificationSubscriber;
import travelAgency.notification.Notification;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class NotificationReceiverImpl implements NotificationReceiver {
    private JmsOperations jmsOperations;
    private boolean running;
    ExecutorService service;
    NotificationSubscriber subscriber;

    public NotificationReceiverImpl(JmsOperations jmsOperations) {
        this.jmsOperations = jmsOperations;
    }

    @Override
    public void start(NotificationSubscriber subscriber) {
        System.out.println("Starting notification receiver...");
        running = true;
        this.subscriber = subscriber;
        service = Executors.newSingleThreadExecutor();
        service.submit(() -> run());
    }

    private void run() {
        while (running) {
            System.out.println("Waiting for notifications...");
            Notification notification =(Notification) jmsOperations.receiveAndConvert();
            System.out.println("Received notification...");
            subscriber.notificationReceived(notification);
        }
    }

    @Override
    public void stop() {
        running = false;
        try {
            service.awaitTermination(10, TimeUnit.MICROSECONDS);
            service.shutdown();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("Stopped notification receiver.");
    }
}
