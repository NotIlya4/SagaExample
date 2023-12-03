using KitchenService.EntityFramework;
using Microsoft.Extensions.Internal;

namespace KitchenService.Domain;

public class TicketServiceFactory(IServiceProvider serviceProvider)
{
    public TicketService Create(AppDbContext context)
    {
        return new TicketService(context, serviceProvider.GetRequiredService<TicketEstimater>(),
            serviceProvider.GetRequiredService<TicketFactory>());
    }
}