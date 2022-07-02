using Confluent.Kafka;

namespace RT.Reports.QueService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReportConsumer();
        }

        private static void ReportConsumer()
        {
            var config = new ConsumerConfig
            {
                GroupId = "test-group",
                BootstrapServers = "127.0.0.1:9092",
                
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using(var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("commands");

                try
                {
                    while (true) { 
                        var result = consumer.Consume();
                        Console.WriteLine($"Message: {result.Message.Value} Topic: {result.TopicPartitionOffset}");
                    }
                }
                catch (ConsumeException ex)
                {
                    Console.WriteLine(ex.Error.Reason);
                }
            }
        }
    }
}