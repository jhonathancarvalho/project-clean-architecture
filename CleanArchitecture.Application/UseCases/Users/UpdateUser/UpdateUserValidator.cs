using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Email)
        .NotEmpty()
        .MaximumLength(50)
        .EmailAddress();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.BirthDate)
                   .NotEmpty().WithMessage("A data de aniversário é obrigatória.")
                   .Must(date => date < DateTime.Today && date <= DateTime.Today.AddYears(-18))
                   .WithMessage("O usuário deve ter pelo menos 18 anos e a data deve ser no passado.");
        }
    }
}
