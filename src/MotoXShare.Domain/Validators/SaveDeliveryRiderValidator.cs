using FluentValidation;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.Domain.Validators;

public class SaveDeliveryRiderValidator : AbstractValidator<SaveDeliveryRiderRequestDto>
{
    public SaveDeliveryRiderValidator()
    {
        RuleFor(d => d.CNPJ)
            .NotEmpty()
            .Length(14).WithMessage("CNPJ inválido.");

        RuleFor(d => d.CNH)
            .NotEmpty()
            .Length(9).WithMessage("CNH inválida.");

        RuleFor(d => d.CNHType)
            .IsInEnum().WithMessage("Tipo de CNH inválido.");
    }
}