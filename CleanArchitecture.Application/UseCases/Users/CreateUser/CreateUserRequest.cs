using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.CreateUser
{
    public sealed record CreateUserRequest(
     string Name,
     string Email,
     string Password,
     DateTimeOffset BirthDate
 ) : IRequest<CreateUserResponse>;
}