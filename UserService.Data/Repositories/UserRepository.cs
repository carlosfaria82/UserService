using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Data.Repositories
{
    public class UserRepository
        : IUserRepository
    {
        private readonly UserServiceContext _context;
        public UserRepository(
            UserServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
