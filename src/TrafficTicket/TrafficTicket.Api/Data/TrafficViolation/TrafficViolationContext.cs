using MongoDB.Driver;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Data
{
    public class TrafficViolationContext : ITrafficViolationContext
    {
        public IMongoCollection<TrafficViolation> TrafficViolations { get; }

        public TrafficViolationContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            var collectionName = "TrafficViolation";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            TrafficViolations = database.GetCollection<TrafficViolation>(collectionName);
            TrafficViolationSeed.SeedData(TrafficViolations);
        }

    }
}
