using CleanArchitecture.Application.UseCases.Users.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.UpdateUser
{
    public sealed record UpdateUserRequest(
       Guid Id,
       string Name,
       string Email,
       DateTimeOffset BirthDate
   ) : IRequest<UpdateUserResponse>;
}

