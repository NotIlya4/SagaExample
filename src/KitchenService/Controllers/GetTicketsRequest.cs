namespace KitchenService.Controllers;

public class GetTicketsRequest
{
    public int Page { get; private set; } = 1;
    public int Limit { get; private set; } = 100;

    public GetTicketsRequest()
    {
        
    }
}