namespace Play.Catalog.Service.DTOs
{
    public record ItemDto (Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreateItem (string Name, string Description , decimal Price);
    public record UpdateTimeDto(string Name, string Description, decimal Price);
}