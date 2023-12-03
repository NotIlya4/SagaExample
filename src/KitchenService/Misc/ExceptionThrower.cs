using System.Diagnostics.CodeAnalysis;
using KitchenService.Domain;

namespace KitchenService.Misc;

public class ExceptionThrower
{
    [DoesNotReturn]
    public static void ApproveCanceledTicket(string internalId)
    {
        throw new InvalidOperationException($"Ticket ${internalId} can't be approved since it canceled");
    }
    
    [DoesNotReturn]
    public static void TicketCannotBePreparedInTime(Ticket ticket, DateTime requestTime, DateTime estimateTime)
    {
        throw new InvalidOperationException(
            $"Ticket ${ticket.InternalId} can't be prepared at {requestTime}, it will be ready only at {estimateTime}");
    }
}