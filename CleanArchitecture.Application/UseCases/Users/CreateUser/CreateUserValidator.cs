using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Users.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(50).WithMessage("O nome deve ter no máximo 50 caracteres.")
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("O nome não pode conter apenas espaços em branco.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .MaximumLength(50).WithMessage("O e-mail deve ter no máximo 50 caracteres.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior à data atual.");
        }
    }
}