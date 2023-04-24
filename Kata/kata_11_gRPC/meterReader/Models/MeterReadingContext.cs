using Microsoft.EntityFrameworkCore;

namespace meterReader.Models;

public class MeterReadingContext : DbContext
{
    public MeterReadingContext(DbContextOptions<MeterReadingContext> options)
        : base(options)
    {

    }
    public DbSet<MeterReading> MeterReadings { get; set; } = null!;

}
