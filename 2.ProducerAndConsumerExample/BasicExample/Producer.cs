using Confluent.Kafka;

namespace _2.ProducerAndConsumerExample.BasicExample;

public class Event
{
    public required string Message { get; init; }
}

public static class Producer
{
    public const string Topic0 = "topic_0";
    
    public static ProducerConfig Config = new ()
    {
        BootstrapServers = "",
        SaslUsername = "",
        SaslPassword = "",
        
        SecurityProtocol = SecurityProtocol.SaslSsl,
        SaslMechanism = SaslMechanism.Plain,
        Acks = Acks.All
    };
    
    public static void MapProducerApi(this WebApplication app)
    {
        app.MapGet("trigger-producer", async (CancellationToken cancellationToken) =>
        {
            using var producer = new ProducerBuilder<string, string>(Config).Build();
            
            producer.Produce(
                Topic0,
                new Message<string, string>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = "Produce: Hello MotherFather! 2"
                }
            );
            
            producer.Flush(cancellationToken);
            
            return "Hello World!";
        });
    }
}