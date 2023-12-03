using KitchenService.Misc;

namespace KitchenService.Domain;

public class Ticket
{
    public int Id { get; private set; }
    public string InternalId { get; private set; }
    public TicketState State { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime FinishTime { get; set; }
    public int Dishes { get; set; }

    protected Ticket()
    {
        InternalId = null!;
    }

    public Ticket(int id, string internalId, TicketState state, DateTime creationDate, DateTime finishTime, int dishes)
    {
        Id = id;
        InternalId = internalId;
        State = state;
        CreationDate = creationDate;
        FinishTime = finishTime;
        Dishes = dishes;
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