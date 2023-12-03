using System.Diagnostics.CodeAnalysis;

namespace KitchenService.Misc;

public class ExceptionThrower
{
    [DoesNotReturn]
    public static void ApproveCanceledTicket(string internalId)
    {
        throw new InvalidOperationException($"Ticket ${internalId} can't be approved since it canceled");
    }
}