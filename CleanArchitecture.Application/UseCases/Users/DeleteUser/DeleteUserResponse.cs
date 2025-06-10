using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.DeleteUser
{
    public sealed record DeleteUserResponse
    {
        public Guid Id { get; init; }
        public string Email { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public bool IsActive { get; init; }
    }
}
