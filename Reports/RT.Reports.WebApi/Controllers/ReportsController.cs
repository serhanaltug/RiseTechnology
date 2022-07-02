using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RT.Contacts.Business.Abstract;

namespace RT.Reports.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {
        IReportService _reports;
        public ReportsController(IReportService reports)
        {
            _reports = reports;
        }

        [HttpGet("{location}")]
        public async Task<IActionResult> GetByLocation(string location)
        {
            var result = _reports.GetByLocation(location);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("requestReport/{location}")]
        public async Task<IActionResult> RequestReport(string location)
        {
            //var result = _reports.GetReport(location);
            //if (result.Success) return Ok(result);
            //else return BadRequest(result);

            if (string.IsNullOrEmpty(location)) return BadRequest();

            //DATABASE e Rapor kayıt edilecek

            await ProduceAsync(location, new Random().Next(1,20));

            return Ok();
        }

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
                    var serializedMessage = JsonConvert.SerializeObject(new { Location = location, RecordId = recordId });

                    var result = await producer.ProduceAsync("commands", new Message<Null, string> { Value = serializedMessage });
                    Console.WriteLine($"\nGönderilen: {result.Value}");
                }
                catch (ProduceException<Null, string> ex)
                {
                    Console.WriteLine(ex.Error.Reason);
                }
            }
        }

    }
}
