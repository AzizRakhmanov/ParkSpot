using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using ParkSpot.DAL.DbAccess;
using ParkSpot.Models;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class ParkSlotRepository<Entity> : IParkSlotRepository<Entity> where Entity : Auditable
    {
        private readonly ParkSlotDbContext _context;

        private readonly DbSet<Entity> _dbSet;
        public ParkSlotRepository(ParkSlotDbContext context,
            DbSet<Entity> dbSet)
        {
            this._context = context;
            this._dbSet = dbSet;
        }
        public async ValueTask<Entity> AddAsync(Entity entity)
        {
            await this._dbSet.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        public Entity Get(Guid id)
        {
            var dbEntity = this._dbSet.Find(id);

            return dbEntity;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> expression)
        {
            var allDbEntites = await this._dbSet.Where(expression).ToListAsync();

            return allDbEntites;
        }

        public bool Remove(Entity entity)
        {
            this._dbSet.Remove(entity);
            var result = this._context.SaveChanges();

            return result > 0 ? true : false;
        }

        public async Task<bool> RemoveRange(Expression<Func<Entity, bool>> expression)
        {
            var dbEntities = this.GetAllAsync(expression);
            this._context.RemoveRange(dbEntities);
            var result = await this._context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

        public async Task UpadateAsync(Entity entity)
        {
            this._dbSet.Update(entity);
            await this._context.SaveChangesAsync();
        }
    }
}
