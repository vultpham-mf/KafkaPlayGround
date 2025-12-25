using System.Text.Json;
using Confluent.Kafka;

namespace _2.ProducerAndConsumerExample.Consumers;

public class CustomJsonDeserializer<T> : IDeserializer<T>
{
    public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        => JsonSerializer.Deserialize<T>(data)!;
}