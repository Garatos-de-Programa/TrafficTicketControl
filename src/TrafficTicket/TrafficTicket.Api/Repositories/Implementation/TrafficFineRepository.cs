using MongoDB.Bson;
using MongoDB.Driver;
using TrafficTicket.Api.Data;
using TrafficTicket.Api.DataContracts.Queries;
using TrafficTicket.Api.Models.TrafficFine;

namespace TrafficTicket.Api.Repositories.Implementation
{
    public class TrafficFineRepository : ITrafficFineRepository
    {
        private readonly ITrafficFineContext _trafficFineContext;

        public TrafficFineRepository(ITrafficFineContext trafficFineContext)
        {
            _trafficFineContext = trafficFineContext;
        }

        public async Task CreateAsync(TrafficFine trafficFine)
        {
            await _trafficFineContext.TrafficFine.InsertOneAsync(trafficFine);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<TrafficFine> filter = Builders<TrafficFine>.Filter.Eq(p => p.Id, id);

            var deleteResult = await _trafficFineContext
                                        .TrafficFine
                                        .DeleteOneAsync(filter);

            var moreThanOneDeleted = deleteResult.DeletedCount > 0;

            return deleteResult.IsAcknowledged &&
                   moreThanOneDeleted;
        }

        public async Task<TrafficFine> GetAsycn(string id)
        {
            return await _trafficFineContext
                           .TrafficFine
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TrafficFine>> GetByDateSearch(DateSearchQuery search)
        {
            var filterBuilder = Builders<TrafficFine>.Filter;

            var endDate = search.CreatedUntil.AddDays(1);

            var filter = filterBuilder.Gte(x => x.CreatedAt, search.CreatedSince) &
                filterBuilder.Lte(x => x.CreatedAt, endDate);

            return await _trafficFineContext
                            .TrafficFine
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<TrafficFine>> GetFinesAsync()
        {
            return await _trafficFineContext
                           .TrafficFine
                           .Find(p => true)
                           .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TrafficFine trafficFine)
        {
            var updateResult = await _trafficFineContext
                                       .TrafficFine
                                       .ReplaceOneAsync(filter: f => f.Id == trafficFine.Id, replacement: trafficFine);

            var moreThanZeroModified = updateResult.ModifiedCount > 0;

            return updateResult.IsAcknowledged &&
                moreThanZeroModified;
        }
    }
}
