using KitchenService.Domain;

namespace KitchenService.Controllers;

public class CreateTicketRequestView
{
    public string InternalId { get; set; } = null!;
    public DateTime FinishTime { get; set; }
    public int Dishes { get; set; }

    public CreateTicketRequest ToRequest()
    {
        return new CreateTicketRequest(InternalId, FinishTime, Dishes);
    }
}