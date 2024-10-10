// Messaging/RabbitMqConsumer.cs
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace PaymentsSystem.Messaging
{
    public class RabbitMqConsumer
    {
        private readonly IModel _channel;

        public RabbitMqConsumer(IModel channel)
        {
            _channel = channel;
        }

        public void Consume(string queueName)
        {
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            };
            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
