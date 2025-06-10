using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.GetAllUser
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;
}