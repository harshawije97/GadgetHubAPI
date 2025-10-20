using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Products.Interfaces;
using Shared.DTO;

namespace Services.Products
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;

        //constructer
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            // create new product
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Category = createProductDTO.Category,
                Price = createProductDTO.Price,
                CreatedAt = DateTime.UtcNow
            };

            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

            return new ProductDTO(
                product.Id,
                product.Name,
                product.Description,
                product.Category,
                product.Price,
                product.CreatedAt
            );
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _appDbContext.Products.AsNoTracking().OrderBy(p => p.Name).ToListAsync();
            // Conversion to a list by arranging it.
            return products.Select(p => new ProductDTO(p.Id, p.Name, p.Description, p.Category, p.Price, p.CreatedAt));
        }

        public async Task<ProductDTO?> GetProductByIDAsync(Guid id)
        {
            var product = await _appDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                return new ProductDTO(product.Id, product.Name, product.Description, product.Category, product.Price, product.CreatedAt);
            }

            return null;
        }

        public async Task<Product?> UpdateProductAsync(Guid id, Product product)
        {
            var updateProduct = await _appDbContext.Products.FindAsync(id);
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Description = product.Description;
                updateProduct.Category = product.Category;
                updateProduct.Price = product.Price;
                updateProduct.UpdatedAt = DateTime.UtcNow;

                _appDbContext.Products.Update(updateProduct);
                await _appDbContext.SaveChangesAsync();

                return updateProduct;
            }

            return null;
        }
        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var removeProduct = await _appDbContext.Products.FindAsync(id);
            if (removeProduct != null)
            {
                _appDbContext.Products.Remove(removeProduct);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
