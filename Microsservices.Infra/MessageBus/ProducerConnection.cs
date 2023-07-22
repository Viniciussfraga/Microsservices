using RabbitMQ.Client;

namespace Microsservices.Infra.MessageBus
{
    //Classe responsavel pela conection com o RabbitMQ
    public class ProducerConnection
    {
        public IConnection Connection { get; private set; }

        public ProducerConnection(IConnection connection)
        {
            Connection = connection;
        }
    }
}
