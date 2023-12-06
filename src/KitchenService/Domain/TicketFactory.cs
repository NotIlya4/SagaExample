using Microsoft.Extensions.Internal;

namespace KitchenService.Domain;

public class TicketFactory(ITicketEstimater estimater, ISystemClock clock) : ITicketFactory
{
    private static TicketValidator _ticketValidator = new();
    
    public async Task<Ticket> CreateNewTicket(CreateTicketRequest request)
    {
        var estimate = await estimater.EstimateFinishTime(request.Dishes);

        var ticket = new Ticket(
            0,
            request.InternalId,
            TicketState.ApprovalPending,
            clock.UtcNow.UtcDateTime,
            request.FinishTime,
            estimate,
            request.Dishes);

        _ticketValidator.Validate(ticket);

        return ticket;
    }
}