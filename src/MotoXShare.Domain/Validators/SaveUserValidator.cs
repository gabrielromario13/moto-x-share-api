using FluentValidation;
using MotoXShare.Domain.Dto.User;

namespace MotoXShare.Domain.Validators;

public class SaveUserValidator : AbstractValidator<SaveUserRequestDto>
{
    public SaveUserValidator()
    {
        RuleFor(u => u.FullName)
            .NotEmpty()
            .Length(3, 100).WithMessage("Nome de usuário deve ter entre 3 e 100 caracteres.");

        RuleFor(u => u.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.UtcNow).WithMessage("Data de nascimento inválida.");
    }
}