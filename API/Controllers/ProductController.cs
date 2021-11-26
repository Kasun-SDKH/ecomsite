
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

       [HttpGet]
       public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _storeContext.Products.ToListAsync();

            return Ok(products);
        }

       [HttpGet("{id:int}")]
       public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);

            return Ok(product);
        }
    }
}
