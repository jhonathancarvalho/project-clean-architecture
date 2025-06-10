using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.DeleteUser
{
    public class DeleteUserValidator :
    AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
