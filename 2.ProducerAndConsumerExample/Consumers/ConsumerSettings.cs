using System.ComponentModel.DataAnnotations;

namespace _2.ProducerAndConsumerExample.Consumers;

public record ConsumerSettings
{
    [Required]
    public required string BootstrapServers { get; init; }
    
    [Required]
    public required string SaslUsername { get; init; }
    
    [Required]
    public required string SaslPassword { get; init; }
}