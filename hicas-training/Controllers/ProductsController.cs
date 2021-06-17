using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hicas_training.Data;
using hicas_training.Models;
using hicas_training.Services.ProductServices;
using hicas_training.Models.DTOs;

namespace hicas_training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductsController(IProduct product)
        {
            _productService = product;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] FilterDTO filterDTO)
        {
            var result = await _productService.GetListProduct(filterDTO);
            return Ok( new { status = true , data = result } );
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new { status = true, data = product });
        }
    }
}
