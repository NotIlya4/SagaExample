using FluentValidation;

namespace KitchenService.Domain;

public class TicketValidator : AbstractValidator<Ticket>
{
    public TicketValidator()
    {
        RuleFor(t => t.RequestTime).Must((t, e) => e >= t.EstimateTime)
            .WithMessage("Request time must be less than estimate");

        RuleFor(t => t.Dishes).GreaterThanOrEqualTo(1);
    }
}