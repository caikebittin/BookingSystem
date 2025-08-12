using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.DataAccess.Repositories;
public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly BookingSystemDbContext _dbContext;

    public UserRepository(BookingSystemDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) =>
        await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
}
