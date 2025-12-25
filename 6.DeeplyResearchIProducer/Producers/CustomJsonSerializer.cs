using System.Text.Json;
using Confluent.Kafka;

namespace _6.DeeplyResearchIProducer.Producers;

public class CustomJsonSerializer<T> : ISerializer<T>
{
    public byte[] Serialize(T data, SerializationContext context) 
        => JsonSerializer.SerializeToUtf8Bytes(data);
}