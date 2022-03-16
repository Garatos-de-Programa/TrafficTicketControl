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
    }
}
