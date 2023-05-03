using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace SenderApi.Service
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration config;

        public QueueService(IConfiguration config)
        {
            this.config = config;
        }
        public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
        {
            QueueClient queueClient = new QueueClient(config.GetConnectionString("EmailNotificationServiceBus"), queueName);
            string jsonMessage = JsonSerializer.Serialize(serviceBusMessage);
            Message message = new Message(Encoding.UTF8.GetBytes(jsonMessage));
            await queueClient.SendAsync(message);

        }
    }
}
