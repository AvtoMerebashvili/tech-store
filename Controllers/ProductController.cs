using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tech_store.Dtos.OrderItems;

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

        [HttpGet]
        [Route("Products")]
        public async Task<ActionResult<ServiceResponse<List<ProductsGetDto>>>> getProducts([FromQuery] ProductsRequest request)
        {
            return await _productsService.getProductsByParams(request);
        }

        [Authorize]
        [HttpGet]
        [Route("GetOrderDetails")]
        public async Task<ServiceResponse<List<OrderGetDto>>> getOrders(int? id)
        {
            return await _productsService.getOrdersByParams(id);
        }

        [Authorize]
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ServiceResponse<List<OrderGetDto>>> createOrder(OrderCreateDto request)
        {
            return await _productsService.createOrder(request);
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveOrder")]
        public async Task<ServiceResponse<List<OrderGetDto>>> removeOrder(int id)
        {
            return await _productsService.removeOrderById(id);
        }

        [Authorize]
        [HttpPost]
        [Route("CreateOrderItems")]
        public async Task<ServiceResponse<List<OrderItemsGetDto>>> createOrderItems(OrderItemsCreateDto request)
        {
            return await _productsService.createOrderItems(request);
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveOrderItems")]
        public async Task<ServiceResponse<List<OrderItemsGetDto>>> RemoveOrderItems(int id)
        {
            return await _productsService.removeOrderItemsById(id);
        }

        [Authorize]
        [HttpPost]
        [Route("SubmitOrderItems")]
        public async Task<ServiceResponse<List<OrderItemsGetDto>>> SubmitOrderItems(int id)
        {
            return await _productsService.SubmitOrderItemsById(id);
        }

        [Authorize]
        [HttpGet]
        [Route("GetBooks")]
        public async Task<ServiceResponse<List<BookGetDto>>> GetBooks(int? id)
        {
            return await _productsService.getBooksByParams(id);
        }

        [Authorize]
        [HttpPost]
        [Route("CreateBook")]
        public async Task<ServiceResponse<List<BookGetDto>>> createBook(BookCreateDto request)
        {
            return await _productsService.createBook(request);
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveBook")]
        public async Task<ServiceResponse<List<BookGetDto>>> removeBook(int id)
        {
            return await _productsService.removeBookById(id);
        }


        //Adimn
        [Authorize]
        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<ActionResult<ServiceResponse<List<ProductsGetDto>>>> addProduct(ProductAddDto request)
        {
            return await _productsService.addNewProduct(request);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<ServiceResponse<List<ProductsGetDto>>>> updateProduct(ProductUpdateDto request)
        {
            return await _productsService.updateProduct(request);
        }
    }
} 
