using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using meterReader.gRPC;
using meterReader.Models;
using static meterReader.gRPC.MeterReaderService;

namespace meterReader.Services;

public class MeterReaderService : MeterReaderServiceBase
{
    private MeterReadingContext _context;
    public MeterReaderService(MeterReadingContext context)
    {
        _context = context;
    }
    public override async Task<StatusMessage> AddReading(ReadingPacket request, ServerCallContext context)
    {
        try
        {
            if (request.Successful == ReadingStatus.Success)
            {
                foreach (var reading in request.Readings)
                {
                    var readingValue = new MeterReading(reading.CustomerId, reading.ReadingValue);

                    _context.Add(readingValue);
                }

                await _context.SaveChangesAsync();
            }

            return new StatusMessage
            {
                Success = ReadingStatus.Success,
                Message = "Successfully added to database"
            };
        }
        catch
        {
            return new StatusMessage
            {
                Success = ReadingStatus.Failure,
                Message = "Failed to store readings in database"
            };
        }

    }
}
