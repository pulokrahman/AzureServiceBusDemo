
using Microsoft.Azure.ServiceBus;
using ReceiverNotifcationApp;
using SharedApp.Model;
using System.Text;
using System.Text.Json;

GetData();

static async Task GetData()
{
    string connectionString = "Endpoint=sb://timetravelingknight.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ugwOO6pi1jgUOp7COdhnpA98WwlpGDGhI+ASbB4Jy6o=";
    string queueName = "emailnotification";
    var queueClient = new QueueClient(connectionString,queueName);
    var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
    {
        MaxConcurrentCalls=1,
        AutoComplete=true
    };
    queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);
    Console.WriteLine("Press Enter to stop");
    Console.ReadLine();
    await queueClient.CloseAsync();
}

static Task ProcessMessageAsync(Message arg1, CancellationToken arg2)
{
    var jsonMessage = Encoding.UTF8.GetString(arg1.Body);
    Customer customer = JsonSerializer.Deserialize<Customer>(jsonMessage);
    EmailNotification notification = new EmailNotification();
    notification.SendEmail(customer);
    return Task.CompletedTask;
}

static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
{
    Console.WriteLine("exception=" + arg);
    return Task.CompletedTask;
}