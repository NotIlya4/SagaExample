namespace KitchenService.Domain;

public record InternalId
{
    public string Value { get; private set; }

    private InternalId()
    {
        Value = null!;
    }

    public InternalId(string internalId)
    {
        Value = internalId;
    }
    
    public static implicit operator string(InternalId internalId)
    {
        return internalId.Value;
    }
    
    public static implicit operator InternalId(string internalId)
    {
        return new InternalId(internalId);
    }
}