using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        bool UserExists(int id);
        Task CreateAsync(User user);
        Task DeleteAsync(int id);
    }
}
