using DataAccess.Entities;
using Shared.DTO;

namespace Services.Products.Interfaces
{
    public interface IProductService
    {
        // Interface to access database actions for Product table - create, read (get all, get by id), update, delete
        Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto);
        Task<ProductDTO?> GetProductByIDAsync(Guid id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<Product?> UpdateProductAsync(Guid id, Product product);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
