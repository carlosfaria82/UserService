using UserService.Application.Dtos;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Application.Mappers
{
    public interface IUserMapperService
    {
        UserDto MapToDto(User u);
        User MapToEntity(UserDto userDto);
        User MapToEntity(UserDto userDto, User user);
    }
}