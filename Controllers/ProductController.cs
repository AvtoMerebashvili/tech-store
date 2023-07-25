using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<OrderGetDto>>> getOrders(int? id)
        {
            // getOrdersByParams
            return null;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult<Boolean>> createOrder(OrderCreateDto request)
        {
            //createOrder
            return null;
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveOrder")]
        public async Task<ActionResult<Boolean>> removeOrder(int id)
        {
            //removeOrderById
            return null;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateOrderItems")]
        public async Task<ActionResult<Boolean>> createOrderItems(OrderItemsCreateDto request)
        {
            //createOrderItems
            return null;
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveOrderItems")]
        public async Task<ActionResult<Boolean>> RemoveOrderItems(int id)
        {
            //removeOrderItemsById
            return null;
        }

        [Authorize]
        [HttpGet]
        [Route("GetBooks")]
        public async Task<ActionResult<List<BookGetDto>>> GetBooks(int? id)
        {
            //getBooksById
            return null;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateBook")]
        public async Task<ActionResult<Boolean>> createBook(BookCreateDto request)
        {
            //createBook
            return null;
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveBook")]
        public async Task<ActionResult<Boolean>> removeBook(int id)
        {
            //getBookById
            return null;
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
