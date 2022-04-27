using MongoDB.Driver;
using TrafficTicket.Api.Models.TrafficFine;

namespace TrafficTicket.Api.Data
{
    public class TrafficFineContext : ITrafficFineContext
    {
        public IMongoCollection<TrafficFine> TrafficFine { get; }

        public TrafficFineContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            var collectionName = "TrafficFine";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            TrafficFine = database.GetCollection<TrafficFine>(collectionName);
            TrafficFineSeed.SeedData(TrafficFine);
        }
    }
}
