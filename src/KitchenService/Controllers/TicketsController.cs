using KitchenService.Domain;
using KitchenService.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.Controllers;

[Route("tickets")]
public class TicketsController(IDbContextFactory<AppDbContext> dbContextFactory, TicketServiceFactory ticketServiceFactory) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(GetTicketsRequest request)
    {
        var tickets = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.ApplyPagination(request.Page, request.Limit).ToListAsync());
        
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
    public async Task<ActionResult<Ticket>> CreateTicket(CreateTicketRequest request)
    {
        var ticket = await dbContextFactory.WithRetry(async context =>
        {
            var ticketService = ticketServiceFactory.Create(context);

            return await ticketService.CreateTicket(request);
        });

        return ticket;
    }
}