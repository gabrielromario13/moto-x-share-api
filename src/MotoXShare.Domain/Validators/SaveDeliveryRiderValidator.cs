using FluentValidation;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.Domain.Validators;

public class SaveDeliveryRiderValidator : AbstractValidator<SaveDeliveryRiderRequestDto>
{
    public SaveDeliveryRiderValidator()
    {
        RuleFor(d => d.CNPJ)
            .NotEmpty()
            .Length(14).WithMessage("CNPJ deve conter 14 dígitos.");

        RuleFor(d => d.CNH)
            .NotEmpty()
            .Length(11).WithMessage("CNH deve conter 11 dígitos.");

        RuleFor(d => d.CNHType)
            .IsInEnum().WithMessage("Tipo de CNH inválido.");
    }
}