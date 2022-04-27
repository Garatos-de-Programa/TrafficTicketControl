using MongoDB.Driver;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Data
{
    public class TrafficViolationSeed
    {
        public static void SeedData(IMongoCollection<TrafficViolation> mongoCollection)
        {
            bool existProduct = mongoCollection.Find(p => true)
                .Any();
            if (!existProduct)
            {
                mongoCollection.InsertManyAsync(GetPreconfigured());
            }
        }

        private static IEnumerable<TrafficViolation> GetPreconfigured()
        {
            return new List<TrafficViolation>()
            {
                new TrafficViolation()
                {
                    Code = "342-2",
                    Id = Guid.NewGuid().ToString(),
                    Name = "Testes"
                }
            };
        }
    }
}
