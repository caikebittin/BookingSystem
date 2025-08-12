using BookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.DataAccess;
public class BookingSystemDbContext : DbContext
{
    public BookingSystemDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingSystemDbContext).Assembly);
    }
}
