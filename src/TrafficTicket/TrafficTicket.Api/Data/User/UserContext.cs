using MongoDB.Driver;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Data
{
    public class UserContext : IUserContext
    {
        public IMongoCollection<User> Users { get; }

        public UserContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            var collectionName = configuration.GetValue<string>("DatabaseSettings:CollectionName");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            Users = database.GetCollection<User>(collectionName);
        }
    }
}
