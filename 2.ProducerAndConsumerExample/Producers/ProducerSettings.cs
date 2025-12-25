using System.ComponentModel.DataAnnotations;

namespace _2.ProducerAndConsumerExample.Producers;

public record ProducerSettings
{
    [Required]
    public required string BootstrapServers { get; init; }
    
    [Required]
    public required string SaslUsername { get; init; }
    
    [Required]
    public required string SaslPassword { get; init; }
}