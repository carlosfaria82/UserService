using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Application.Services
{
    public interface IUserMgmtService
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
