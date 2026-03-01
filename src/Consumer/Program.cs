using Consumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared;
using Simone.Common.RabbitMQ.Extensions;

var configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json")
 .Build();

var services = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration);
services.AddLogging(configure => configure.AddConsole());

services.AddRabbitMQ(configuration)
    .AddConsumer<ChatMessage, ChatConsumer>(services: services);

services.BuildServiceProvider();

Console.WriteLine("Consumer is running. Press any key to exit...");
Console.ReadKey();