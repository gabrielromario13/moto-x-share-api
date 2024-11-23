using FluentValidation;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class SaveDeliveryRiderValidator : AbstractValidator<SaveDeliveryRiderRequestDto>
{
    public SaveDeliveryRiderValidator()
    {
        RuleFor(d => d.CNPJ)
            .NotEmpty()
            .Length(14).WithMessage("CNPJ deve conter 14 dígitos.");

        RuleFor(u => u.FullName)
            .NotEmpty()
            .Length(3, 100).WithMessage("Nome de usuário deve ter entre 3 e 100 caracteres.");

        RuleFor(u => u.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.UtcNow).WithMessage("Data de nascimento inválida.");

        RuleFor(d => d.CNH)
            .NotEmpty()
            .Length(11).WithMessage("CNH deve conter 11 dígitos.");

        RuleFor(d => d.CNHType)
            .IsInEnum().WithMessage("Tipo de CNH inválido.");
    }
}