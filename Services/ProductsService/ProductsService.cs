using Azure;
using Microsoft.AspNetCore.Mvc;
using tech_store.DbModels;
using tech_store.DbModels.Products;

namespace tech_store.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        public readonly TechStoreContext _context;
        public readonly IMapper _mapper;
        public ProductsService(TechStoreContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductsGetDto>>> addNewProduct(ProductAddDto newProduct)
        {
            var response = new ServiceResponse<List<ProductsGetDto>>();
            var dbProduct = _mapper.Map<Product>(newProduct);
            await _context.AddAsync(dbProduct);
            await _context.SaveChangesAsync();
            var dbProducts = _context.products.ToList();
            var productsDto = dbProducts.Select(x=>_mapper.Map<ProductsGetDto>(x)).ToList();
            response.result = productsDto;
            return response;
        }

        public async Task<ServiceResponse<List<BookGetDto>>> createBook(BookCreateDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<OrderGetDto>> createOrder(OrderCreateDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<OrderItemsGetDto>>> createOrderItems(OrderItemsCreateDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<BookGetDto>>> getBooksByParams(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> getOrdersByParams(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductsGetDto>>> getProductsByParams(ProductsRequest request)
        {
            var response = new ServiceResponse<List<ProductsGetDto>>();
            var dbProducts = _context.products.ToList();
            var productsDto = dbProducts.Select(x => _mapper.Map<ProductsGetDto>(x)).ToList();
            response.result = productsDto;
            return response;
        }

        public async Task<ServiceResponse<bool>> removeBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> removeOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> removeOrderItemsById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductsGetDto>>> updateProduct(ProductUpdateDto request)
        {
            throw new NotImplementedException();
        }
    }
}
