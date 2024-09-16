using ParkSpot.Models;
using System.Linq.Expressions;

namespace DAL.IRepository
{
    public interface IParkSlotRepository<Entity> where Entity : Auditable
    {
        public Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity,bool>> expression);

        public Entity Get(Guid id);

        public ValueTask<Entity> AddAsync(Entity entity);

        public bool Remove(Entity entity);

        public Task<bool> RemoveRange(Expression<Func<Entity,bool>> expression);

        public Task UpadateAsync(Entity entity);
    }
}
