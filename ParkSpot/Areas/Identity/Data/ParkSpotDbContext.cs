using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkSpot.Areas.Identity.Data;
using ParkSpot.Models;

namespace ParkSpot.Data;

public class ParkSpotDbContext : IdentityDbContext<UserLoginModel>
{
    public ParkSpotDbContext(DbContextOptions<ParkSpotDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ParkSpot.Models.User> User { get; set; } = default!;
}
