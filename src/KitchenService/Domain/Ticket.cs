using KitchenService.Misc;

namespace KitchenService.Domain;

public class Ticket
{
    public int Id { get; private set; }
    public string InternalId { get; private set; } = null!;
    public TicketState State { get; private set; }

    protected Ticket()
    {
        
    }

    public Ticket(int id, string internalId, TicketState state)
    {
        Id = id;
        InternalId = internalId;
        State = state;
    }

    public void Approve()
    {
        if (State == TicketState.Canceled)
        {
            ExceptionThrower.ApproveCanceledTicket(InternalId);
        }

        State = TicketState.Approved;
    }
}

public enum TicketState
{
    ApprovalPending,
    Approved,
    Canceled,
    Finished
}