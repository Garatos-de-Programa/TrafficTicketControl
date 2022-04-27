using MongoDB.Driver;
using TrafficTicket.Api.Models;
using TrafficTicket.Api.Models.TrafficFine;

namespace TrafficTicket.Api.Data
{
    public class TrafficFineSeed
    {
        public static void SeedData(IMongoCollection<TrafficFine> mongoCollection)
        {
            bool existProduct = mongoCollection.Find(p => true)
                .Any();
            if (!existProduct)
            {
                mongoCollection.InsertManyAsync(GetPreconfigured());
            }
        }

        private static IEnumerable<TrafficFine> GetPreconfigured()
        {
            return new List<TrafficFine>()
            {
                new TrafficFine()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    Placa = "tes-3342",
                    Latitude = 324234234,
                    Longitude = -34234324,
                    Active = true,
                    Computed = true,
                    TrafficViolations = new List<TrafficViolation>()
                    {
                        new TrafficViolation()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Code = "232",
                            Name = "Teste"
                        }
                    }
                }
            };
        }
    }
}
