using KitchenService.Misc;

namespace KitchenService.Domain;

public record Ticket
{
    public int Id { get; private set; }
    public InternalId InternalId { get; private set; }
    public TicketState State { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime RequestTime { get; private set; }
    public DateTime EstimateTime { get; private set; }
    public int Dishes { get; private set; }

    protected Ticket()
    {
        InternalId = null!;
    }

    public Ticket(int id, InternalId internalId, TicketState state, DateTime creationDate, DateTime requestTime, DateTime estimateTime, int dishes)
    {
        Id = id;
        InternalId = internalId;
        State = state;
        CreationDate = creationDate;
        RequestTime = requestTime;
        EstimateTime = estimateTime;
        Dishes = dishes;
    }

    public void Approve()
    {
        if (State == TicketState.Canceled)
        {
            ExceptionThrower.ApproveCanceledTicket(InternalId);
        }

        if (State == TicketState.ApprovalPending)
        {
            State = TicketState.Approved;
        }
    }
}