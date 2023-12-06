using KitchenService.Domain;

namespace KitchenService.Controllers;

public class TicketView
{
    public int Id { get; private set; }
    public string InternalId { get; private set; } = null!;
    public TicketState State { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime RequestTime { get; private set; }
    public DateTime EstimateTime { get; private set; }
    public int Dishes { get; private set; }

    public static TicketView FromModel(Ticket ticket)
    {
        return new TicketView()
        {
            Id = ticket.Id,
            InternalId = ticket.InternalId,
            State = ticket.State,
            CreationDate = ticket.CreationDate,
            RequestTime = ticket.RequestTime,
            EstimateTime = ticket.EstimateTime,
            Dishes = ticket.Dishes
        };
    }
    
    public static IEnumerable<TicketView> FromModel(IEnumerable<Ticket> tickets)
    {
        return tickets.Select(TicketView.FromModel);
    }

    public static implicit operator TicketView(Ticket ticket)
    {
        return TicketView.FromModel(ticket);
    }
}