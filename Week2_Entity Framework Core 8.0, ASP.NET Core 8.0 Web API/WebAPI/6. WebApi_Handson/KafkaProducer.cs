using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace WebApiDemo.Kafka
{
    public class KafkaProducer
    {
        public static async Task Produce(string topic, string message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            Console.WriteLine($"Delivered to: {result.TopicPartitionOffset}");
        }
    }
}
