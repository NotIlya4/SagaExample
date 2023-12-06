using KitchenService.Misc;
using Microsoft.Extensions.Internal;

namespace KitchenService.Domain;

public class TicketEstimater(IBusyHoursProvider busyHoursProvider, ISystemClock clock) : ITicketEstimater
{
    public async Task<DateTime> EstimateFinishTime(int dishes)
    {
        var hourCoefficient = await busyHoursProvider.GetCurrentTimeCoefficient();
        TimeSpan ticketWouldTake = dishes * hourCoefficient * TimeSpan.FromHours(1);

        return clock.UtcNow.UtcDateTime + ticketWouldTake;
    }
}