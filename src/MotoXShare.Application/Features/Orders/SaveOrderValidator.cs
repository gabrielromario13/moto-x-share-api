using FluentValidation;

namespace MotoXShare.Application.Features.Orders;

public class SaveOrderValidator : AbstractValidator<SaveOrderRequestDto>
{
    public SaveOrderValidator()
    {
        RuleFor(o => o.DeliveryPrice)
            .NotEmpty();

        RuleFor(o => o.Status)
            .IsInEnum();

        RuleFor(o => o.CreatedAt)
            .NotEmpty();
    }
}