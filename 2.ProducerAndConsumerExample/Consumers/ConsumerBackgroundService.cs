using _2.ProducerAndConsumerExample.Producers;
using Confluent.Kafka;

namespace _2.ProducerAndConsumerExample.Consumers;

public class ConsumerBackgroundService(ILogger<ConsumerBackgroundService> logger, IConsumer<string, Event> consumer) : BackgroundService
{
    public const string Topic0 = "topic_0";

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        consumer.Subscribe("topic_0");

        while (!cancellationToken.IsCancellationRequested)
        {
            var consumeResult = consumer.Consume(cancellationToken);
            
            // TODO: Call your handler here
            await Task.Delay(0, cancellationToken);
            logger.LogInformation($"Key {consumeResult.Message.Key ?? "Shit"} - Value {consumeResult.Message.Value.Message}");
        }
    }
}