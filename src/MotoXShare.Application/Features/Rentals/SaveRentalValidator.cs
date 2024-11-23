using FluentValidation;

namespace MotoXShare.Application.Features.Rentals;

public class SaveRentalValidator : AbstractValidator<SaveRentalRequestDto>
{
    public SaveRentalValidator()
    {
        RuleFor(r => r.DeliveryRiderId)
            .NotEmpty();

        RuleFor(r => r.PlanType)
            .IsInEnum().WithMessage("Tipo de plano inválido.");

        RuleFor(r => r.ExpectedEndDate)
            .NotEmpty()
            .GreaterThan(DateTime.UtcNow).WithMessage("Data de previsão de termino inválida.");

        RuleFor(r => r.EndDate)
            .NotEmpty()
            .GreaterThan(DateTime.UtcNow).WithMessage("Data de termino inválida.");
    }
}