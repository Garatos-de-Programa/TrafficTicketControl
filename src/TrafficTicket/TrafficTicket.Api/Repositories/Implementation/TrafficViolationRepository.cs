using MongoDB.Driver;
using TrafficTicket.Api.Data;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Repositories.Implementation
{
    public class TrafficViolationRepository : ITrafficViolationRepository
    {
        private readonly ITrafficViolationContext _trafficViolationContext;

        public TrafficViolationRepository(ITrafficViolationContext trafficViolationContext)
        {
            _trafficViolationContext = trafficViolationContext;
        }

        public async Task CreateAsync(TrafficViolation trafficViolation)
        {
            await _trafficViolationContext.TrafficViolations.InsertOneAsync(trafficViolation);
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<TrafficViolation> filter = Builders<TrafficViolation>.Filter.Eq(p => p.Id, id);

            var deleteResult = await _trafficViolationContext
                                        .TrafficViolations
                                        .DeleteOneAsync(filter);

            var moreThanOneDeleted = deleteResult.DeletedCount > 0;

            if (!deleteResult.IsAcknowledged && !moreThanOneDeleted)
            {
                throw new InvalidOperationException("unknown traffic violation");
            }
        }

        public async Task<TrafficViolation> GetAsycn(string id)
        {
            return await _trafficViolationContext
                              .TrafficViolations
                              .Find(p => p.Id == id)
                              .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TrafficViolation>> GetTrafficsViolationsAsync()
        {
            return await _trafficViolationContext
                              .TrafficViolations
                              .Find(p => true)
                              .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TrafficViolation trafficViolation)
        {
            var updateResult = await _trafficViolationContext
                                       .TrafficViolations
                                       .ReplaceOneAsync(filter: f => f.Id == trafficViolation.Id, replacement: trafficViolation);

            var moreThanZeroModified = updateResult.ModifiedCount > 0;

            return updateResult.IsAcknowledged &&
                moreThanZeroModified;
        }
    }
}
