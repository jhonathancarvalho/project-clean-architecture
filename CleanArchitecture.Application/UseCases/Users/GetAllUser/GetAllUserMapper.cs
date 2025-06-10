using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Users.GetAllUser
{
    public sealed class GetAllUserMapper : Profile
    {
        public GetAllUserMapper()
        {
            CreateMap<User, GetAllUserResponse>();
        }
    }
}
