using FluentValidation;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Nome de usuário é obrigatório")
            .MinimumLength(3).WithMessage("Nome de usuário deve ter pelo menos 3 caracteres")
            .MaximumLength(50).WithMessage("Nome de usuário não pode exceder 50 caracteres");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome completo é obrigatório")
            .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório")
            .EmailAddress().WithMessage("Formato de email inválido")
            .MaximumLength(100).WithMessage("Email não pode exceder 100 caracteres");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória")
            .MinimumLength(8).WithMessage("Senha deve ter pelo menos 8 caracteres")
            .Matches("[A-Z]").WithMessage("Senha deve conter pelo menos 1 letra maiúscula")
            .Matches("[a-z]").WithMessage("Senha deve conter pelo menos 1 letra minúscula")
            .Matches("[0-9]").WithMessage("Senha deve conter pelo menos 1 número")
            .Matches("[^a-zA-Z0-9]").WithMessage("Senha deve conter pelo menos 1 caractere especial");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Perfil inválido");
    }
}