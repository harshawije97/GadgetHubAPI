using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Products.Interfaces;
using Shared.DTO;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GadgetHubAPI.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIDAsync(id);

                if(product != null)
                {
                    return Ok(product);
                }

                return NotFound(new {message = "Requested Product Not Found", data= product});
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO createProductDTO)
        {
            try
            {
                // Basic validation before post
                if (string.IsNullOrWhiteSpace(createProductDTO.Name) || createProductDTO.Price <= 0 || string.IsNullOrWhiteSpace(createProductDTO.Category))
                {
                    return BadRequest(new { message = "Product Name, Product Price & Category are required" });
                }

                var response = await _productService.CreateProductAsync(createProductDTO);
                return Ok(
                    new
                    {
                        id = response.Id,
                        name = response.Name,
                        category = response.Category,
                        description = response.Description
                    });
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product updatedProduct)
        {
            try
            {
                var response = await _productService.UpdateProductAsync(id, updatedProduct);
                if (response != null)
                {
                    return Ok(
                        new
                        {
                            id = response.Id,
                            name = response.Name,
                            category = response.Category,
                            description = response.Description,
                            price = response.Price
                        });
                }

                return NotFound(new { message = "Requested Product Not Found" });
            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    message = error.ToString()
                });
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(id);
                if (response)
                {
                    return NoContent();
                }
                return NotFound(new { message = "Requested Product Not Found" });

            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    message = error.ToString()
                });
            }
        }

        // Before testing controllers
        private Exception NotImplementedException()
        {
            throw new NotImplementedException();
        }
    }
}
