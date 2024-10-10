// Messaging/RabbitMqConnection.cs
using RabbitMQ.Client;
using System;

namespace PaymentsSystem.Messaging
{
    public class RabbitMqConnection : IDisposable
    {
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqConnection(string hostName)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public IModel GetChannel() => _channel;

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}
