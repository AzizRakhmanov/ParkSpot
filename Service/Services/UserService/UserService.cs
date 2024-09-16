using DAL.IRepository;
using DAL.Repository;
using ParkSpot.Models;

namespace Service.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IParkSlotRepository<User> _repository;

        public UserService(IParkSlotRepository<User> repository)
        {
            this._repository = repository;
        }

        public async ValueTask<User> AddAsync(User user)
        {
            if (user is null)
                throw new Exception(message:"adding user can't be null");

            return await this._repository.AddAsync(user);
        }

        public bool Delete(Guid id)
        {
            if (id == Guid.Empty)
                return false;

            var @object = this._repository.Get(id);

            if (@object is null)
                return false;

            return this._repository.Remove(@object);
        }

        public bool DeleteRangeAsync(IEnumerable<User> users)
        {
            return true;
        }

        public async Task<IEnumerable<User>> RetrieveAllAsync()
        {
            return await this._repository.GetAllAsync(p => p.Id != Guid.Empty);
        }

        public User Retrieve(Guid id)
        => this._repository.Get(id);

        public async ValueTask<User> UpdateAsync(User user)
        {
            var dbUser = this._repository.Get(user.Id);

            if (dbUser.Equals(null)) 
                return null;

            await this._repository.UpadateAsync(dbUser);

            return user;
        }
    }
}
