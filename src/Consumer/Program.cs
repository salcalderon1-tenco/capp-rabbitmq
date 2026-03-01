using Consumer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Shared;
using Simone.Common.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(builder.Configuration), preserveStaticLogger: true);

builder.Services.AddRabbitMQ(builder.Configuration)
.AddConsumer<ChatMessage, ChatConsumer>(services: builder.Services);

var app = builder.Build();
await app.RunAsync();