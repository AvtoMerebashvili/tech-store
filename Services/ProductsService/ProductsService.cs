using tech_store.DbModels;

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
            //var dbProduct = _mapper.Map<ProductAddDto>(newProduct);
            
            //_context.
            //await _context.SaveChangesAsync();
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        public async Task<ServiceResponse<List<ProductUpdateDto>>> updateProduct(ProductUpdateDto request)
        {
            throw new NotImplementedException();
        }
    }
}
