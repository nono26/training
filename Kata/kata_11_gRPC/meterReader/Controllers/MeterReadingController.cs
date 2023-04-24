using meterReader.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MeterReadingController : ControllerBase
{

    private MeterReadingContext _context;
    private readonly ILogger<MeterReadingController> _logger;

    public MeterReadingController(MeterReadingContext context, ILogger<MeterReadingController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetMeterReadings")]
    public IEnumerable<MeterReading> Get()
    {
        var data = _context.MeterReadings.OrderBy(x => x.CustomerId);
        return data;
    }
}
