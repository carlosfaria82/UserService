using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Application.Dtos;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Application.Services
{
    public interface IUserMgmtService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, UserDto userDto);
        bool UserExists(int id);
        Task<User> CreateAsync(UserDto user);
        Task DeleteAsync(int id);
    }
}
