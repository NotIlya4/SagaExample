namespace KitchenService.Domain;

public class CreateTicketRequest
{
    public InternalId InternalId { get; private set; }
    public DateTime FinishTime { get; private set; }
    public int Dishes { get; private set; }

    public CreateTicketRequest()
    {
        InternalId = null!;
    }

    public CreateTicketRequest(string internalId, DateTime finishTime, int dishes)
    {
        InternalId = internalId;
        FinishTime = finishTime;
        Dishes = dishes;
    }
}