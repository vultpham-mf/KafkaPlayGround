using Confluent.Kafka;

namespace _2.ProducerAndConsumerExample.Producers;

public class TriggerProducerApi
{
    public static void Map(WebApplication app)
    {
        app.MapGet("trigger-producer", (IProducer<string, Event> producer) =>
        {
            producer.Produce(
                "topic_0",
                new Message<string, Event>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = new Event
                    {
                        Message = "Hello MotherFather!"
                    }
                }
            );
            
            producer.Flush();
            
            return "Hello World!";
        });   
    }
}