using Simone.Common.RabbitMQ.Models;

namespace Shared;

public class ChatMessage : IMessageHeader
{
    public string Type => nameof(ChatMessage);
    public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    public int Index => 0;
    public Queue? Queue { get; set; }
    public IEnumerable<(string CorrelationId, int Index)> RelatedCorrelationIds { get; set; } = [];
    public string Chat { get; set; } = string.Empty;
}
