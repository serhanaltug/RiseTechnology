using Microsoft.AspNetCore.Mvc;
using RT.Contacts.Business.Abstract;
using RT.Contacts.Domain.Entities;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _reports.GetAll();
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _reports.GetById(id);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("location/{location}")]
        public async Task<IActionResult> GetByLocation(string location)
        {
            if (string.IsNullOrEmpty(location)) return BadRequest();

            var result = _reports.GetByLocation(location);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("requestReport/{location}")]
        public async Task<IActionResult> RequestReport(string location)
        {
            if (string.IsNullOrEmpty(location)) return BadRequest();

            var report = new Report { Konum = location };
            _reports.Add(report);

            await Producer.ProduceAsync(location, report.UUID);

            return Ok();
        }
    }
}
