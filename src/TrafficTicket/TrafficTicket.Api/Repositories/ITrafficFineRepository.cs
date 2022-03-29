using TrafficTicket.Api.Models.TrafficFine;

namespace TrafficTicket.Api.Repositories
{
    public interface ITrafficFineRepository
    {
        Task<IEnumerable<TrafficFine>> GetFinesAsync();

        Task<TrafficFine> GetAsycn(string id);

        Task CreateAsync(TrafficFine trafficFine);

        Task<bool> UpdateAsync(TrafficFine trafficFine);

        Task<bool> DeleteAsync(string id);
    }
}
