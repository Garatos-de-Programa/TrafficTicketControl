using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Repositories
{
    public interface ITrafficViolationRepository
    {
        Task<IEnumerable<TrafficViolation>> GetTrafficsViolationsAsync();

        Task<TrafficViolation> GetAsycn(string id);

        Task DeleteAsync(string id);

        Task<bool> UpdateAsync(TrafficViolation trafficViolation);

        Task CreateAsync(TrafficViolation trafficViolation);
    }
}
