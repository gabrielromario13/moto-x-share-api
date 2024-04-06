using FluentValidation;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.Domain.Validators;

public class SaveDeliveryRiderValidator : AbstractValidator<SaveDeliveryRiderRequestDto>
{
    public SaveDeliveryRiderValidator()
    {
        RuleFor(d => d.FullName)
            .NotEmpty()
            .Length(3, 100).WithMessage("Nome de usuário deve ter entre 3 e 100 caracteres.");

        RuleFor(d => d.CNPJ)
            .NotEmpty()
            .Length(14).WithMessage("CNPJ inválido.");

        RuleFor(d => d.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.UtcNow).WithMessage("Data de nascimento inválida.");

        RuleFor(d => d.CNH)
            .NotEmpty()
            .Length(9).WithMessage("CNH inválida.");

        RuleFor(d => d.CNHType)
            .IsInEnum().WithMessage("Tipo de CNH inválido.");
    }
}