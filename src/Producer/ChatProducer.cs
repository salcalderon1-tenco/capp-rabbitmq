using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared;
using Simone.Common.RabbitMQ.Models;
using Simone.Common.RabbitMQ.Services;

namespace Producer;

public class ChatProducer(IServiceScopeFactory scopeFactory, ILoggerFactory loggerFactory)
: BasePublisherService(scopeFactory, loggerFactory)
{
    public const string ServiceKey = nameof(ChatProducer);
    public override string ProcessName => nameof(ChatProducer);
    public async Task<SendMessageResults> SendChatMessageAsync(string message)
    {
        var chatMessage = new ChatMessage
        {
            Chat = message,
            CorrelationId = CorrelationId.NewId()
        };
        return await Send(chatMessage);
    }
}
