namespace Shared.DTO
{
    public record ProductDTO(Guid Id, string Name, string? Description, string Category, decimal Price, DateTime? CreatedAt);
}
