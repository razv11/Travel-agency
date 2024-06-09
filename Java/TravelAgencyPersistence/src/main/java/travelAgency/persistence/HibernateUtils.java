package travelAgency.persistence;

import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import travelAgency.model.User;

public class HibernateUtils {
    private static SessionFactory sessionFactory;

    public static SessionFactory getSessionFactory() {
        if((sessionFactory == null) || (sessionFactory.isClosed())) {
            sessionFactory = createNewSessionFactory();
        }

        return sessionFactory;
    }

    public static SessionFactory createNewSessionFactory() {
        sessionFactory = new Configuration()
                .addAnnotatedClass(User.class)
                .buildSessionFactory();

        return sessionFactory;
    }

    public static void closeSessionFactory() {
        if(sessionFactory != null) {
            sessionFactory.close();
        }
    }
}
