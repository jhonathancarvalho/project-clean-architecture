using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.UseCases.Users.CreateUser
{
    public sealed class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ConstructUsing(request => new User(
                    request.Name,
                    new Email(request.Email),
                    string.Empty,
                    DateTimeOffset.MinValue
                ));

            CreateMap<User, CreateUserResponse>();
        }
    }
}