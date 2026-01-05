using System.ComponentModel.DataAnnotations;
using Confluent.Kafka;

namespace _2.ProducerAndConsumerExample.Producers;

public record ProducerSettings
{
    [Required]
    public required string BootstrapServers { get; init; }
    
    public string? SaslUsername { get; init; }
    
    public string? SaslPassword { get; init; }
    
    public SecurityProtocol? SecurityProtocol { get; init; }
}