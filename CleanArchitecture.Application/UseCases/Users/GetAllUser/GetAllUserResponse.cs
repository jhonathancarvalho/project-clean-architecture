using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.GetAllUser
{
    public class GetAllUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public DateTimeOffset BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}