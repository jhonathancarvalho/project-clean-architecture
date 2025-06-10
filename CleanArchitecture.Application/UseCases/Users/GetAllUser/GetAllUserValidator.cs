using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.GetAllUser
{
    public class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
    {
        public GetAllUserValidator()
        {
        }
    }
}
