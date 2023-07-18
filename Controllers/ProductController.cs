using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;
using tech_store.DbModels.Products;

namespace tech_store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
         private readonly TechStoreContext _context;

        public ProductController(TechStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Products")]
        public async Task<ActionResult<List<Product>>> getProducts(){
            return await this._context.products.ToListAsync();
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<List<Product>>> registerProduct()
        {
            return null;
        }

    }
}