using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using System;
using UserService.Application.Dtos;
using UserService.Application.Mappers;
using UserService.Domain.Aggregates.UserAgg;
using Xunit;

namespace UserService.Tests.UnitTests
{
    public class UserMapperServiceTests
    {
        [Fact]
        public void MapToDto_Returns_UserDto()
        {
            var user = new User { Name = "Test", Birthdate = new DateTime(1982, 07, 16) };

            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization() { ConfigureMembers = true });

            var userMapperService = fixture.Create<UserMapperService>();

            var result = userMapperService.MapToDto(user);

            result.Should().BeOfType<UserDto>();
        }

        [Fact]
        public void MapToDto_Returns_Null_When_InputIsNull()
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization() { ConfigureMembers = true });

            var userMapperService = fixture.Create<UserMapperService>();

            var result = userMapperService.MapToDto(null);

            result.Should().BeNull();
        }
    }
}
