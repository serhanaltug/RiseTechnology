using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RT.Contacts.Business.Abstract;
using RT.Contacts.CompositionRoot;
using RT.Reports.QueService.Models;

namespace RT.Reports.QueService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reports = new DataAccess();
            ReportConsumer(reports);
        }

        private static void ReportConsumer(DataAccess reports)
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
                        var response = JsonConvert.DeserializeObject<ResponseModel>(result.Message.Value);
                        reports.UpdateReport(response.RecordId).Wait();
                        Console.WriteLine($"{result.Message.Value}");
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