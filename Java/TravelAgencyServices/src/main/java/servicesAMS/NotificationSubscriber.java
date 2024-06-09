package servicesAMS;

import travelAgency.notification.Notification;

public interface NotificationSubscriber {
    void notificationReceived(Notification notification);
}
