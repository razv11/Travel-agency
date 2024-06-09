package servicesAMS;

public interface NotificationReceiver {
    void start(NotificationSubscriber subscriber);
    void stop();
}
