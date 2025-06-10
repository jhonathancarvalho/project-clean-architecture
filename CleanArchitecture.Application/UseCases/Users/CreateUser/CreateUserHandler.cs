using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.Hash(request.Password);
            var email = new Email(request.Email);

            var user = new User(
                name: request.Name,
                email: email,
                passwordHash: hashedPassword,
                birthDate: request.BirthDate
            );

            _userRepository.Create(user);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
