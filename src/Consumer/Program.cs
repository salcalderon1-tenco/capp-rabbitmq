using Consumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Shared;
using Simone.Common.RabbitMQ.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddSerilog((context, config) => config.ReadFrom.Configuration(builder.Configuration), preserveStaticLogger: true);

builder.Services.AddRabbitMQ(builder.Configuration)
.AddConsumer<ChatMessage, ChatConsumer>(services: builder.Services);

var app = builder.Build();
await app.RunAsync();