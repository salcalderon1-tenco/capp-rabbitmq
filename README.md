# Basic use of RabbitMQ in Simon-e

This is a simple example of how to use RabbitMQ in Simon-e. It demonstrates how to create a connection, declare a queue, and publish messages to the queue.

## Getting Started

### Initialize RabbitMQ
This project uses depends on RabbitMQ and Simone.Infrastructure, please make sure that `simone_rabbit_mq_node1` container is running. 
Follow the instructions in [Simone Infrastructure](https://github.com/tenco-rd/Simone.Infrastructure) to set up the infrastructure.

### Configure RabbitMQ in consumer and producer
In the `appsettings.json` file of both the consumer and producer projects, add the following configuration for RabbitMQ:

```json
{
  "RabbitMQ": {
    "HostName": "localhost", // localhost works
    "UserName": "guest", // Username for RabbitMQ
    "Password": "guest", // Password for RabbitMQ
  }
}
```

### Run the Producer and Consumer
1. Start the RabbitMQ container using Docker.
2. Run the consumer project to start listening for messages.
3. Run the producer project to send messages to the queue.

Open the console in each project an execute `dotnet run` to start the applications. You should see the producer sending messages and the consumer receiving them.
