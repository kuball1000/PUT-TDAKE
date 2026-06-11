package lab.ejb;
import jakarta.ejb.ActivationConfigProperty;
import jakarta.ejb.MessageDriven;
import jakarta.jms.JMSDestinationDefinition;
import jakarta.jms.JMSException;
import jakarta.jms.Message;
import jakarta.jms.ObjectMessage;
import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;

@MessageDriven(activationConfig = {
        @ActivationConfigProperty(propertyName =
                "destinationLookup", propertyValue = "java:app/jms/NewsQueue"),
        @ActivationConfigProperty(propertyName = "destinationType",
                propertyValue = "jakarta.jms.Queue")
})
@JMSDestinationDefinition(name = "java:app/jms/NewsQueue",
        interfaceName = "jakarta.jms.Queue", resourceAdapter = "jmsra",
        destinationName = "NewsQueue")
public class NewsMDB implements jakarta.jms.MessageListener {
    @PersistenceContext
    private EntityManager em;


    @Override
    public void onMessage(Message message) {
//        ObjectMessage msg = null;
//        try {
//            if (message instanceof ObjectMessage) {
//                msg = (ObjectMessage) message;
//                NewsItem e = (NewsItem) msg.getObject();
//                em.persist(e);
//            }
//        } catch (JMSException e) {
//            e.printStackTrace();
//        }

        try {
            if (message instanceof jakarta.jms.TextMessage txtMeg) {
                String payload = txtMeg.getText();

                String[] parts = payload.split("\\|");

                if (parts.length == 2) {
                    NewsItem e = new NewsItem();
                    e.setHeading(parts[0]);
                    e.setBody(parts[1]);
                    em.persist(e);
                }
            }
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
