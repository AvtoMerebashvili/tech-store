namespace tech_store.Services.ProductsService
{
    public interface IProductsService
    {
        Task<ServiceResponse<List<ProductsGetDto>>> getProductsByParams(ProductsRequest request);
        Task<ServiceResponse<List<OrderGetDto>>> getOrdersByParams(int id);
        Task<ServiceResponse<OrderGetDto>> createOrder(OrderCreateDto request);
        Task<ServiceResponse<bool>> removeOrderById(int id);
        Task<ServiceResponse<List<OrderItemsGetDto>>> createOrderItems(OrderItemsCreateDto request);
        Task<ServiceResponse<bool>> removeOrderItemsById(int id);
        Task<ServiceResponse<List<BookGetDto>>> getBooksByParams(int? id);
        Task<ServiceResponse<List<BookGetDto>>> createBook(BookCreateDto request);
        Task<ServiceResponse<bool>> removeBookById(int id);
        Task<ServiceResponse<List<ProductsGetDto>>> addNewProduct(ProductAddDto newProduct);
        Task<ServiceResponse<List<ProductsGetDto>>> updateProduct(ProductUpdateDto request);
    }
}
