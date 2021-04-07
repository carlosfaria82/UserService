using System;
using System.Linq;
using UserService.Domain.Aggregates.UserAgg;

namespace UserService.Data.Extensions
{
    public static class UserServiceContextExtensions
    {
        public static void SeedData(this UserServiceContext context)
        {
            context.
                SeedUsers();

            context.SaveChanges();
        }

        public static UserServiceContext SeedUsers(this UserServiceContext context)
        {
            var hasUsers = context.HasDataEntity<User>();
            if (!hasUsers)
                context.Users.AddRange(
                    new User
                    {
                        Name = "Cesar",
                        Birthdate = new DateTime(2021, 03, 24)
                    },
                    new User 
                    {
                        Name = "Sauron",
                        Birthdate = new DateTime(1971, 01, 31)
                    });
            return context;
        }

        public static bool HasDataEntity<TEntity>(this UserServiceContext context)
          where TEntity : class
        {
            return context.Set<TEntity>().Any();
        }
    }
}
