using Microsoft.AspNetCore.Mvc;
using HelpStockApp.Application.DTOs;
using HelpStockApp.Application.Interfaces;

namespace HelpStockApp.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProducts")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var products = await _productService.GetProductById(id);
            if (products == null)
            {
                return NotFound("Product not found");
            }
            return Ok(products);
        }
    }
}