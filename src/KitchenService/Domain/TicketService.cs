using KitchenService.EntityFramework;
using KitchenService.Misc;

namespace KitchenService.Domain;

public class TicketService(AppDbContext context, TicketEstimater estimater, TicketFactory factory)
{
    public async Task<Ticket> CreateTicket(CreateTicketRequest request)
    {
        var ticket = factory.CreateNew(request.InternalId, request.FinishTime, request.Dishes);

        if (!estimater.CanTicketBeServedInTime(ticket))
        {
            ExceptionThrower.TicketCannotBePreparedInTime(ticket, request.FinishTime,
                estimater.EstimateFinishTime(request.Dishes));
        }

        context.Tickets.Add(ticket);
        await context.SaveChangesAsync();

        return ticket;
    }
}