namespace _2.ProducerAndConsumerExample.Producers;

public record Event
{
    public required string Message { get; init; }
}