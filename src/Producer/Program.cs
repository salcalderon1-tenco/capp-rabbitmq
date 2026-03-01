using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Producer;
using Serilog;
using Simone.Common.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(builder.Configuration), preserveStaticLogger: true);
builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.TryAddTransient<ChatProducer>();

var app = builder.Build();
_  = app.StartAsync();

// Request message input from the user and send it to the consumer
var chatProducer = app.Services.GetRequiredService<ChatProducer>();
while (true)
{
    Console.Write("Enter a message to send (or 'exit' to quit): ");
    var input = Console.ReadLine();
    if (input?.ToLower() == "exit")
        break;

    var result = await chatProducer.SendChatMessageAsync(input ?? "No message provided");
    Console.WriteLine($"Message sent with result: {result}");
}
