using Microsoft.EntityFrameworkCore;
using ParkSpot.Models;

namespace ParkSpot.DAL.DbAccess
{
    public class ParkSlotDbContext : DbContext
    {
        public ParkSlotDbContext(DbContextOptions<ParkSlotDbContext> options)
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}
