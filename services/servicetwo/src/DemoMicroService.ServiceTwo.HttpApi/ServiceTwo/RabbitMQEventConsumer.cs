using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace DemoMicroService.ServiceTwo
{
    
    public class RabbitMQEventConsumer
    {
        private readonly IConnection _connection;

        public RabbitMQEventConsumer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            _connection = factory.CreateConnection();
        }

        public void ConsumeMessage(string queueName, Action<string> handleText)
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                handleText(message);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }

}
