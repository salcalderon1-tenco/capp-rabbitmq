using Shared;
using Simone.Common.RabbitMQ.Abstractions;

namespace Consumer;

public class ChatConsumer() : IConsumer<ChatMessage>
{
    public async Task<(bool acknowledge, string? reason)> Process(ChatMessage message, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Message received: " + message.Chat);
        return (true, null);
    }
}
