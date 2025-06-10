using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.Email.Address == email, cancellationToken);
        }
    }
}