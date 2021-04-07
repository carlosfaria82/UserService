using System;
using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Aggregates.UserAgg
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
