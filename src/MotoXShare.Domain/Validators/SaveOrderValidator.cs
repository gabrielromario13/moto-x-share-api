using FluentValidation;
using MotoXShare.Domain.Dto.Order;

namespace MotoXShare.Domain.Validators;

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