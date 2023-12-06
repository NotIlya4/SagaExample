using System.ComponentModel;
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
    public async Task<ActionResult<IEnumerable<TicketView>>> GetTickets(Pagination request)
    {
        var tickets = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.OrderBy(t => t.Id).ApplyPagination(request).ToListAsync());
        
        return TicketView.FromModel(tickets).ToList();
    }

    [HttpGet("internalId/{internalId}")]
    public async Task<ActionResult<TicketView>> GetTicket(string internalId)
    {
        var ticket = await dbContextFactory.WithRetry(async context =>
            await context.Tickets.SingleAsync(t => t.InternalId == internalId));
        
        return TicketView.FromModel(ticket);
    }

    [HttpPost]
    public async Task<ActionResult<TicketView>> CreateTicket([FromBody] CreateTicketRequestView request)
    {
        var ticket = await dbContextFactory.WithRetry(async context =>
        {
            var ticket = await ticketFactory.CreateNewTicket(request.ToRequest());

            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            return ticket;
        });

        return TicketView.FromModel(ticket);
    }

    [HttpPost("{internalId}/approve")]
    public async Task<ActionResult> ApproveTicket(string internalId)
    {
        await dbContextFactory.WithRetry(async context =>
        {
            var ticket = await context.GetTicketByInternalId(internalId);
            
            ticket.Approve();

            await context.SaveChangesAsync();
        });

        return NoContent();
    }
}