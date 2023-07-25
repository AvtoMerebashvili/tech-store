using tech_store.Dtos.OrderItems;

namespace tech_store.Services.ProductsService
{
    public interface IProductsService
    {
        Task<ServiceResponse<List<ProductsGetDto>>> getProductsByParams(ProductsRequest request);
        Task<ServiceResponse<List<OrderGetDto>>> getOrdersByParams(int? id);
        Task<ServiceResponse<List<OrderGetDto>>> createOrder(OrderCreateDto request);
        Task<ServiceResponse<List<OrderGetDto>>> removeOrderById(int id);
        Task<ServiceResponse<List<OrderItemsGetDto>>> createOrderItems(OrderItemsCreateDto newOrderItems);
        Task<ServiceResponse<List<OrderItemsGetDto>>> removeOrderItemsById(int id);
        Task<ServiceResponse<List<OrderItemsGetDto>>> SubmitOrderItemsById(int id);
        Task<ServiceResponse<List<BookGetDto>>> getBooksByParams(int? id);
        Task<ServiceResponse<List<BookGetDto>>> createBook(BookCreateDto newBook);
        Task<ServiceResponse<List<BookGetDto>>> removeBookById(int id);
        Task<ServiceResponse<List<ProductsGetDto>>> addNewProduct(ProductAddDto newProduct);
        Task<ServiceResponse<List<ProductsGetDto>>> updateProduct(ProductUpdateDto updatedProduct);
    }
}
