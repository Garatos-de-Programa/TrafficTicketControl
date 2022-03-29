using MongoDB.Driver;
using TrafficTicket.Api.Models.TrafficFine;

namespace TrafficTicket.Api.Data
{
    public interface ITrafficFineContext
    {
        IMongoCollection<TrafficFine> TrafficFine { get; }
    }
}
