using Microsoft.Extensions.Internal;

namespace KitchenService.Domain;

public class TicketEstimater(BusyHoursProvider busyHoursProvider, ISystemClock clock)
{
    public bool CanTicketBeServedInTime(Ticket ticket)
    {
        return CanTicketBeServedInTime(ticket.Dishes, ticket.FinishTime);
    } 
    
    public bool CanTicketBeServedInTime(int dishes, DateTime finishTime)
    {
        var estimate = EstimateFinishTime(dishes);

        return estimate <= finishTime;
    }

    public DateTime EstimateFinishTime(int dishes)
    {
        TimeSpan ticketWouldTake = dishes * busyHoursProvider.GetCurrentTimeCoefficient() * TimeSpan.FromHours(1);

        return clock.UtcNow.UtcDateTime + ticketWouldTake;
    }
}