using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Data.Repositories;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Application.Services
{
    public class UserMgmtService
        : IUserMgmtService
    {
        private readonly IUserRepository _userRepository;

        public UserMgmtService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
