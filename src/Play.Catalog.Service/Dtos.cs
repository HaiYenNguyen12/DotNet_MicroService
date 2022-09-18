using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.DTOs
{
    public record ItemDto (Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreateItem ([Required] string Name,string Description , [Range(0,1000)] decimal Price);
    public record UpdateTimeDto([Required] string Name, string Description, [Range(0,1000)] decimal Price);
}