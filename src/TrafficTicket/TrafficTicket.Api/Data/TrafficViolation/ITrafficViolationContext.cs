using MongoDB.Driver;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Data
{
    public interface ITrafficViolationContext
    {
        IMongoCollection<TrafficViolation> TrafficViolations { get; }
    }
}
