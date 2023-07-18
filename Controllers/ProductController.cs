using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;
using tech_store.DbModels.Products;
using tech_store.Dtos.Books;
using tech_store.Dtos.Orders;
using tech_store.Dtos.Products;

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
        public async Task<ActionResult<List<ProductsGetDto>>> getProducts(ProductsRequest request)
        {
            //return await this._context.products.ToListAsync();
            return null;
        }

        [HttpGet]
        [Route("GetOrderDetails")]
        public async Task<ActionResult<List<OrderGetDto>>> getOrder(int? id)
        {
            return null;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult<Boolean>> createOrder(OrderCreateDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveOrder")]
        public async Task<ActionResult<Boolean>> removeOrder(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("CreateOrderItems")]
        public async Task<ActionResult<Boolean>> createOrderItems(OrderItemsCreateDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveOrderItems")]
        public async Task<ActionResult<Boolean>> RemoveOrderItems(int id)
        {
            return null;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<ActionResult<List<BookGetDto>>> createBook(int? id)
        {
            return null;
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<ActionResult<Boolean>> createBook(BookCreateDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveBook")]
        public async Task<ActionResult<Boolean>> removeBook(int id)
        {
            return null;
        }


        //Adimn

        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<ActionResult<Boolean>> addProduct(ProductAddDto request)
        {
            return null;
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<Boolean>> updateProduct(ProductUpdateDto request)
        {
            return null;
        }
    }
} 
