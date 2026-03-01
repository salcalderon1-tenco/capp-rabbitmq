using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json")
 .Build();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
