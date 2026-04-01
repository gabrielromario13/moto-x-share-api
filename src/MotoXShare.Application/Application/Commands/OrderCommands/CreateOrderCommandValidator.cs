using FluentValidation;

namespace MotoXShare.Core.Application.Commands.OrderCommands;

internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.DeliveryPrice)
            .NotEmpty();

        RuleFor(o => o.Status)
            .IsInEnum();

        RuleFor(o => o.CreatedAt)
            .NotEmpty();
    }
}