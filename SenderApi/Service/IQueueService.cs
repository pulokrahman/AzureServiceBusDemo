namespace SenderApi.Service
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string queueName);
    }
}