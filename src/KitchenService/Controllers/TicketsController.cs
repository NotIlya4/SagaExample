using KitchenService.Domain;
using KitchenService.EntityFramework;
using KitchenService.Misc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.Controllers;

[Route("tickets")]
public class TicketsController(IDbContextFactory<AppDbContext> dbContextFactory, TicketService ticketService) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(GetTicketsRequest request)
    {
        var tickets = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.ApplyPagination(request.Page, request.Limit).ToListAsync());
        
        return tickets;
    }

    [HttpGet]
    public async Task<ActionResult<Ticket>> GetTicket(string internalId)
    {
        var ticket = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.SingleAsync(t => t.InternalId == internalId));
        
        return ticket;
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> CreateTicket(CreateTicketRequest request)
    {
        var ticket = await ticketService.CreateTicket(request);

        return ticket;
    }
}

public class GetTicketsRequest
{
    public int Page { get; private set; } = 1;
    public int Limit { get; private set; } = 100;

    protected GetTicketsRequest()
    {
        
    }
}

