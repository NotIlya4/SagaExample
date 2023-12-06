using KitchenService.Domain;
using KitchenService.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.EntityFramework;

namespace KitchenService.Controllers;

[Route("tickets")]
public class TicketsController(IDbContextFactory<KitchenDbContext> dbContextFactory, ITicketFactory ticketFactory) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(Pagination request)
    {
        var tickets = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.ApplyPagination(request).ToListAsync());
        
        return tickets;
    }

    [HttpGet("internalId/{internalId}")]
    public async Task<ActionResult<Ticket>> GetTicket(string internalId)
    {
        var ticket = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.SingleAsync(t => t.InternalId == internalId));
        
        return ticket;
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> CreateTicket([FromBody] CreateTicketRequestView request)
    {
        var ticket = await dbContextFactory.WithRetry(async context =>
        {
            var ticket = await ticketFactory.CreateNewTicket(request.ToRequest());

            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            return ticket;
        });

        return ticket;
    }
}