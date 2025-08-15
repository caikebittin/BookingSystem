using BookingSystem.Domain.Repositories;

namespace BookingSystem.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly BookingSystemDbContext _dbContext;

    public UnitOfWork(BookingSystemDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
