namespace KitchenService.Domain;

public interface ITicketFactory
{
    Task<Ticket> CreateNewTicket(CreateTicketRequest request);
}