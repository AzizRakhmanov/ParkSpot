using ParkSpot.Models;

namespace Service.Services.UserService
{
    public interface IUserService
    {
        public ValueTask<User> AddAsync(User user);

        public ValueTask<User> UpdateAsync(User user);

        public bool Delete(Guid id);

        public bool DeleteRangeAsync(IEnumerable<User> users);

        public Task<IEnumerable<User>> RetrieveAllAsync();

        public User Retrieve(Guid id);
    }
}
