using TrafficTicket.Api.DataContracts.Queries;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetAsycn(string id);

        Task<User> GetAsycn(UserSearchQuery userSearchQuery);

        Task CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(string id);
    }
}
