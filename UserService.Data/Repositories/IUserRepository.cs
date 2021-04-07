using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
