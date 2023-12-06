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
    public static void TicketCannotBePreparedInTime(string ticketInternalId, DateTime requestTime, DateTime estimateTime)
    {
        throw new InvalidOperationException(
            $"Ticket ${ticketInternalId} can't be prepared at {requestTime}, it will be ready only at {estimateTime}");
    }
    
    [DoesNotReturn]
    public static void TicketWithInternalIdNotFound(InternalId ticketInternalId)
    {
        throw new InvalidOperationException($"Ticket with internal id ${ticketInternalId} not found");
    }
}