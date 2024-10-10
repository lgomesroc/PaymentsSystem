// Messaging/RabbitMqPublisher.cs
using RabbitMQ.Client;
using System.Text;

namespace PaymentsSystem.Messaging
{
    public class RabbitMqPublisher
    {
        private readonly IModel _channel;

        public RabbitMqPublisher(IModel channel)
        {
            _channel = channel;
        }

        public void Publish(string message, string queueName)
        {
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                  routingKey: queueName,
                                  basicProperties: null,
                                  body: body);
        }
    }
}
