using MongoDB.Driver;
using TrafficTicket.Api.Data;
using TrafficTicket.Api.Models;

namespace TrafficTicket.Api.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext;

        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task CreateAsync(User user)
        {
            await _userContext.Users.InsertOneAsync(user);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(p => p.Id, id);

            var deleteResult = await _userContext
                                        .Users
                                        .DeleteOneAsync(filter);

            var moreThanOneDeleted = deleteResult.DeletedCount > 0;

            return deleteResult.IsAcknowledged &&
                   moreThanOneDeleted;
        }

        public async Task<User> GetAsycn(string id)
        {
            return await _userContext
                           .Users
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext
                           .Users
                           .Find(p => true)
                           .ToListAsync();
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var updateResult = await _userContext
                                       .Users
                                       .ReplaceOneAsync(filter: f => f.Id == user.Id, replacement: user);

            var moreThanZeroModified = updateResult.ModifiedCount > 0;

            return updateResult.IsAcknowledged &&
                moreThanZeroModified;
        }
    }
}
