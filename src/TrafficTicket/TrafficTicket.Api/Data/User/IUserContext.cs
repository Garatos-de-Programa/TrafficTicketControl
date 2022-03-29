using MongoDB.Driver;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Data
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
