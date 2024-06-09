package travelAgency.serverAMS;

import org.springframework.jms.core.JmsOperations;
import servicesAMS.ITravelAgencyNotificationService;
import travelAgency.model.Reservation;
import travelAgency.notification.Notification;
import travelAgency.notification.NotificationType;

public class NotificationServiceImpl implements ITravelAgencyNotificationService {
    private JmsOperations jmsOperations;

    public NotificationServiceImpl(JmsOperations jmsOperations) {
        this.jmsOperations = jmsOperations;
    }

    @Override
    public void newReservation(Reservation reservation) {
        System.out.println("Trip reserved notification");
        Notification notification = new Notification(NotificationType.TRIP_RESERVED, reservation.getTrip().getId(), reservation.getNumberOfTickets());
        jmsOperations.convertAndSend(notification);
        System.out.println("Sent object to ActiveMQ.." + notification);
    }
}
