using Confluent.Kafka;
using Newtonsoft.Json;

namespace RT.Reports.WebApi
{
    public static class Producer
    {
        public static async Task ProduceAsync(string location, int recordId)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "127.0.0.1:9092"
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var serializedMessage = JsonConvert.SerializeObject(new { RecordId = recordId, Location = location });

                    var result = await producer.ProduceAsync("commands", new Message<Null, string> { Value = serializedMessage });
                }
                catch (ProduceException<Null, string> ex)
                {
                    Console.WriteLine(ex.Error.Reason);
                }
            }
        }
        public static void Produce(string location, int recordId) => ProduceAsync(location, recordId).Wait();

    }
}
