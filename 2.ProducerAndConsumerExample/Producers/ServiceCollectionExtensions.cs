using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace _2.ProducerAndConsumerExample.Producers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProducer(this IServiceCollection services)
    {
        services
            .AddOptionsWithValidateOnStart<ProducerSettings>()
            .BindConfiguration(nameof(ProducerSettings))
            .ValidateDataAnnotations();
        
        services.AddSingleton<IProducer<string, Event>>(serviceProvider =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<ProducerSettings>>().Value;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = settings.BootstrapServers,
                SaslUsername = settings.SaslUsername,
                SaslPassword = settings.SaslPassword,
                
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                Acks = Acks.All,
            };
            
            return new ProducerBuilder<string, Event>(producerConfig)
                .SetKeySerializer(Serializers.Utf8)
                .SetValueSerializer(new CustomJsonSerializer<Event>())
                .Build();
        });
        
        return services;
    }
}