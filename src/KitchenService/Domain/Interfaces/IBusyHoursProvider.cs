namespace KitchenService.Domain;

public interface IBusyHoursProvider
{
    Task<float> GetCurrentTimeCoefficient();
}