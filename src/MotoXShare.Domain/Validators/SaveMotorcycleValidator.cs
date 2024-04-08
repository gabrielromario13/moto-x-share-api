using FluentValidation;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.Domain.Validators;

public class SaveMotorcycleValidator : AbstractValidator<SaveMotorcycleRequestDto>
{
    public SaveMotorcycleValidator()
    {
        RuleFor(m => m.Year)
            .NotEmpty().WithMessage("Ano é obrigatório.");

        RuleFor(m => m.Model)
            .NotEmpty().WithMessage("Modelo é obrigatório.");

        RuleFor(m => m.Plate)
            .NotEmpty().WithMessage("Placa é obrigatória.");
    }
}