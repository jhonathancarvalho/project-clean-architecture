using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork,
                                 IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest command,
                                             CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(command.Id, cancellationToken);

            if (user is null) return default;

            user.SetName(command.Name);
            user.SetEmail(new Email(command.Email)); 
            user.SetBirthDate(command.BirthDate);

            _userRepository.Update(user);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<UpdateUserResponse>(user);
        }
    }
}
