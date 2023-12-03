namespace KitchenService.EntityFramework;

public class Pagination
{
    public int Page { get; private set; } = 1;
    public int Limit { get; private set; } = 100;

    public Pagination()
    {
        
    }

    public Pagination(int page, int limit)
    {
        Page = page;
        Limit = limit;
    }
}