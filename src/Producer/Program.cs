using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Producer;
using Simone.Common.RabbitMQ.Extensions;

var configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json")
 .Build();

var services = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration);
services.AddLogging(configure => configure.AddConsole());
services.AddRabbitMQ(configuration);
services.TryAddSingleton<ChatProducer>();

services.BuildServiceProvider();

// Request message input from the user and send it to the consumer
var chatProducer = services.BuildServiceProvider().GetRequiredService<ChatProducer>();
while (true)
{
    Console.Write("Enter a message to send (or 'exit' to quit): ");
    var input = Console.ReadLine();
    if (input?.ToLower() == "exit")
        break;

    var result = await chatProducer.SendChatMessageAsync(input ?? "No message provided");
    Console.WriteLine($"Message sent with result: {result}");
}
