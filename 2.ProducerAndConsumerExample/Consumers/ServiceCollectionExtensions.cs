using _2.ProducerAndConsumerExample.Producers;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace _2.ProducerAndConsumerExample.Consumers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConsumer(this IServiceCollection services)
    {
        services
            .AddOptionsWithValidateOnStart<ConsumerSettings>()
            .BindConfiguration(nameof(ConsumerSettings))
            .ValidateDataAnnotations(); // Optional

        services.AddSingleton<IConsumer<string, Event>>(serviceProvider =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<ConsumerSettings>>().Value;

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = settings.BootstrapServers,
                SaslUsername = settings.SaslUsername,
                SaslPassword = settings.SaslPassword,

                SecurityProtocol = settings.SecurityProtocol ?? SecurityProtocol.Plaintext,
                SaslMechanism = settings.SaslUsername != null ? SaslMechanism.Plain : null,
                GroupId = "group-id-1",
        
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            return new ConsumerBuilder<string, Event>(consumerConfig)
                .SetKeyDeserializer(Deserializers.Utf8)
                .SetValueDeserializer(new CustomJsonDeserializer<Event>())
                .Build();
        });
        
        services.AddHostedService<ConsumerBackgroundService>();
        
        return services;
    }
}