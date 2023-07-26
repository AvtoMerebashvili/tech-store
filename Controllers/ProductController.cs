using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tech_store.Dtos.OrderItems;
using tech_store.Filters;

namespace tech_store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("Products")]
        public async Task<ActionResult<ServiceResponse<List<ProductsGetDto>>>> getProducts([FromQuery] ProductsRequest request)
        {
            return await _productsService.getProductsByParams(request);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpGet("GetOrderDetails")]
        public async Task<ServiceResponse<List<OrderGetDto>>> getOrders(int? id)
        {
            return await _productsService.getOrdersByParams(id);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpPost("CreateOrder")]
        public async Task<ServiceResponse<List<OrderGetDto>>> createOrder(OrderCreateDto request)
        {
            return await _productsService.createOrder(request);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpDelete("RemoveOrder")]
        public async Task<ServiceResponse<List<OrderGetDto>>> removeOrder(int id)
        {
            return await _productsService.removeOrderById(id);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpPost("CreateOrderItems")]
        public async Task<ServiceResponse<List<OrderItemsGetDto>>> createOrderItems(OrderItemsCreateDto request)
        {
            return await _productsService.createOrderItems(request);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpDelete("RemoveOrderItems")]
        public async Task<ServiceResponse<List<OrderItemsGetDto>>> RemoveOrderItems(int id)
        {
            return await _productsService.removeOrderItemsById(id);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpPost("SubmitOrderItems")]
        public async Task<ServiceResponse<List<OrderItemsGetDto>>> SubmitOrderItems(int id)
        {
            return await _productsService.SubmitOrderItemsById(id);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpGet("GetBooks")]
        public async Task<ServiceResponse<List<BookGetDto>>> GetBooks(int? id)
        {
            return await _productsService.getBooksByParams(id);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpPost("CreateBook")]
        public async Task<ServiceResponse<List<BookGetDto>>> createBook(BookCreateDto request)
        {
            return await _productsService.createBook(request);
        }

        [Authorize]
        [RoleFilter("user")]
        [HttpDelete("RemoveBook")]
        public async Task<ServiceResponse<List<BookGetDto>>> removeBook(int id)
        {
            return await _productsService.removeBookById(id);
        }


        //Adimn
        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddNewProduct")]
        public async Task<ActionResult<ServiceResponse<List<ProductsGetDto>>>> addProduct(ProductAddDto request)
        {
            return await _productsService.addNewProduct(request);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<ServiceResponse<List<ProductsGetDto>>>> updateProduct(ProductUpdateDto request)
        {
            return await _productsService.updateProduct(request);
        }
    }
} 
