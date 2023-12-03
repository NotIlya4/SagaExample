using Microsoft.Extensions.Internal;

namespace KitchenService.Domain;

public class TicketFactory(ISystemClock clock)
{
    public Ticket CreateNew(string internalId, DateTime finishTime, int dishes)
    {
        return new Ticket(0, internalId, TicketState.ApprovalPending, clock.UtcNow.UtcDateTime, finishTime, dishes);
    }
}