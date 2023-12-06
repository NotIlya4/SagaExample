using Microsoft.Extensions.Internal;

namespace KitchenService.Domain;

public class BusyHoursProvider(ISystemClock clock) : IBusyHoursProvider
{
    private const float MorningCoef = 1.1f;
    private const float DayCoef = 2f;
    private const float NightCoef = 0.8f;

    public Task<float> GetCurrentTimeCoefficient()
    {
        return Task.FromResult(clock.UtcNow.Hour switch
        {
            var h when h >= 5 && h < 12 => MorningCoef,
            var h when h >= 12 && h < 18 => DayCoef,
            var h when h >= 18 || h < 5 => NightCoef,
            _ => 1f
        });
    }
}