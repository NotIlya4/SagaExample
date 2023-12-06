namespace KitchenService.Domain;

public interface ITicketEstimater
{
    Task<DateTime> EstimateFinishTime(int dishes);
}