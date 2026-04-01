using FluentValidation;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public class CreateMotorcycleCommandValidator : AbstractValidator<CreateMotorcycleCommand>
{
    public CreateMotorcycleCommandValidator()
    {
        RuleFor(m => m.Year)
            .NotEmpty().WithMessage("Ano é obrigatório.");

        RuleFor(m => m.Model)
            .NotEmpty().WithMessage("Modelo é obrigatório.");

        RuleFor(m => m.Plate)
            .NotEmpty().WithMessage("Placa é obrigatória.");
    }
}