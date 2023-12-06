using KitchenService.Domain;
using KitchenService.Misc;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.EntityFramework;

public static class DbContextExtensions
{
    public static async Task<Ticket> GetTicketByInternalId(this KitchenDbContext context, InternalId internalId)
    {
        var ticket = await context.Tickets.SingleOrDefaultAsync(t => t.InternalId == internalId);

        if (ticket is null)
        {
            ExceptionThrower.TicketWithInternalIdNotFound(internalId);
        }
        
        return ticket;
    }
}