using Microsoft.EntityFrameworkCore;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Data
{
    public class UserApiContext
        : DbContext
    {
        public UserApiContext(DbContextOptions<UserApiContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
