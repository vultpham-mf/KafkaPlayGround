using Confluent.Kafka;

namespace _2.ProducerAndConsumerExample.BasicExample;

public class Consumer(ILogger<Consumer> logger) : BackgroundService
{
    public const string Topic0 = "topic_0";

    public static ConsumerConfig Config = new()
    {
        BootstrapServers = "pkc-817wq.ap-east-1.aws.confluent.cloud:9092",
        SaslUsername = "L2CQNGJNDECU6MTP",
        SaslPassword = "cfltqqBP8QxwZnG00rxojej22eY3nvWuEwRjJmhEXjx+p0YrxNsE9eb6GyKpnLBA",
        
        SecurityProtocol = SecurityProtocol.SaslSsl,
        SaslMechanism = SaslMechanism.Plain,
        GroupId = "group5",
        
        AutoOffsetReset = AutoOffsetReset.Latest
    };

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1, stoppingToken);
        
        using var consumer = new ConsumerBuilder<string, string>(Config).Build();
        consumer.Subscribe(Topic0);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var cr = consumer.Consume(stoppingToken);
            logger.LogInformation($"Key {cr.Message.Key ?? "Shit"} - Value {cr.Message.Value ?? "Shit"}");
        }
    }
}