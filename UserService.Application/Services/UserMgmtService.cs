using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Application.Dtos;
using UserService.Application.Mappers;
using UserService.Data.Repositories;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Application.Services
{
    public class UserMgmtService
        : IUserMgmtService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapperService _userMapperService;

        public UserMgmtService(
            IUserRepository userRepository, 
            IUserMapperService userMapperService)
        {
            _userRepository = userRepository;
            _userMapperService = userMapperService;
        }

        public async Task<User> CreateAsync(UserDto userDto)
        {
            var user = _userMapperService.MapToEntity(userDto);
            await _userRepository.CreateAsync(user);
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => _userMapperService.MapToDto(u));            
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _userMapperService.MapToDto(user);
        }

        public async Task UpdateAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userUpdated = _userMapperService.MapToEntity(userDto, user);
            await _userRepository.UpdateAsync(userUpdated);
        }

        public bool UserExists(int id)
        {
            return _userRepository.UserExists(id);
        }
    }
}
