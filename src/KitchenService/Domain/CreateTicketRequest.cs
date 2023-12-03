namespace KitchenService.Domain;

public class CreateTicketRequest
{
    public string InternalId { get; private set; }
    public DateTime FinishTime { get; private set; }
    public int Dishes { get; private set; }

    protected CreateTicketRequest()
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