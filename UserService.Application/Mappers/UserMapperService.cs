using UserService.Application.Dtos;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Application.Mappers
{
    public class UserMapperService
        : IUserMapperService
    {
        public UserDto MapToDto(User user)
        {
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user?.Name,
                Birthdate = user.Birthdate
            };
        }

        public User MapToEntity(UserDto userDto)
        {
            if (userDto == null)
                return null;

            return new User
            {
                Name = userDto.Name,
                Birthdate = userDto.Birthdate
            };
        }

        public User MapToEntity(UserDto userDto, User user)
        {
            user.Name = userDto.Name;
            user.Birthdate = userDto.Birthdate;
            return user;
        }
    }
}
