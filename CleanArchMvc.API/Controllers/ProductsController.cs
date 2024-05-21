using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get() 
        {
            var products = await _productService.GetProducts();

            if (products == null) 
            {
                return NotFound("Products not found.");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get([FromRoute] int id) 
        {
            var product = await _productService.GetById(id);

            if (product == null) 
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }
    }
}
