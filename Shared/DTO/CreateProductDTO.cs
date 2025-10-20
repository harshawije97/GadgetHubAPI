using System;

namespace Shared.DTO
{
    public record CreateProductDTO(string Name, string? Description, string Category, decimal Price);
}
