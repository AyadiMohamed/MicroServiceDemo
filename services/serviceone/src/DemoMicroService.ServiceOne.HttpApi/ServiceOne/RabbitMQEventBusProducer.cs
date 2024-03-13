
using RabbitMQ.Client;
using System.Text;
namespace DemoMicroService.ServiceOne
{


    public class RabbitMQEventBusProducer
    {
        private readonly IConnection _connection;

        public RabbitMQEventBusProducer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            _connection = factory.CreateConnection();
        }

        public void PublishMessage(string queueName, string message)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true, 
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }


    }
}
