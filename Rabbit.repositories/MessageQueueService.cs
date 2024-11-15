using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Rabbit.Repositories
{
    public class MessageQueueService<T>
    {
        private readonly ConnectionFactory _factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "admin",
            Password = "123456"
        };
        private IModel? _channel;

        public MessageQueueService()
        {
            InitializeChannel();
        }

        private void InitializeChannel()
        {
            var connection = _factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void PublishMessage(string queueName, T message)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            string json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body);
        }

        public void ConsumerMessage(string queueName)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                T mensagem = JsonSerializer.Deserialize<T>(json);
                Thread.Sleep(1000);
                Console.WriteLine(JsonSerializer.Serialize(mensagem));
            };
            _channel.BasicConsume(queue: queueName, consumer: consumer);
        }
    }
}
