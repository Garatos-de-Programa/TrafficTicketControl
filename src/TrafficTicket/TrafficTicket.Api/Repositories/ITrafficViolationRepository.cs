using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Repositories
{
    public interface ITrafficViolationRepository
    {
        Task<IEnumerable<TrafficViolation>> GetTrafficsViolationsAsync();

        Task<TrafficViolation> GetAsycn(string id);
    }
}
