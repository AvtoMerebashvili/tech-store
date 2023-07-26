using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;
using tech_store.DbModels.Products;
using tech_store.Dtos.OrderItems;
using tech_store.Dtos.Products;
using tech_store.Services.TokenService;

namespace tech_store.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly TechStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public ProductsService(TechStoreContext context, IMapper mapper, ITokenService tokenService) {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<ServiceResponse<List<ProductsGetDto>>> addNewProduct(ProductAddDto newProduct)
        {
            var response = new ServiceResponse<List<ProductsGetDto>>();
            var dbProduct = _mapper.Map<Product>(newProduct);
            dbProduct.creator_id = _tokenService.getUserId();
            await _context.AddAsync(dbProduct);
            await _context.SaveChangesAsync();
            var dbProducts = _context.products.ToList();
            var productsDto = dbProducts.Select(x=>_mapper.Map<ProductsGetDto>(x)).ToList();
            response.result = productsDto;
            return response;
        }

        public async Task<ServiceResponse<List<BookGetDto>>> createBook(BookCreateDto newBook)
        {
            var response = new ServiceResponse<List<BookGetDto>>();
            var dbBook = _mapper.Map<Order>(newBook);
            var userId = _tokenService.getUserId();
            dbBook.owner_id = userId;
            await _context.orders.AddAsync(dbBook);
            await _context.SaveChangesAsync();
            var dbBooks = _context.orders.Where(order => order.is_book && order.owner_id == userId).ToList();
            var bookGetDto = dbBooks.Select(x=> _mapper.Map<BookGetDto>(x)).ToList();
            response.result = bookGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> createOrder(OrderCreateDto newOrder)
        {
            var response = new ServiceResponse<List<OrderGetDto>>();
            var dbOrder = _mapper.Map<Order>(newOrder);
            var userId = _tokenService.getUserId();
            dbOrder.owner_id = userId;
          
            if (newOrder.orderItemsId != null)
                dbOrder.order_items_id = (int)newOrder.orderItemsId;
            else
            {
                var newOrderItems = new OrderItem
                {
                    name = "DefaultName",
                    is_active = true,
                    owner_id = userId,
                };
                await _context.order_items.AddAsync(newOrderItems);
                await _context.SaveChangesAsync();
                var justAddedOrderItem = await _context.order_items.OrderByDescending(x => x.create_date).Take(1).FirstAsync();
                dbOrder.order_items_id = justAddedOrderItem.id;
            }

            if (newOrder.isBook)
            {
                var book = await _context.orders.FirstOrDefaultAsync(order =>
                     order.is_book && order.id == newOrder.id
                    );
                dbOrder.id = book.id;
                dbOrder.product_id = book.product_id;
                dbOrder.is_book = false;
                dbOrder.active = true;
                if(book.order_items_id != null) dbOrder.order_items_id = book.order_items_id;
                _context.orders.Update(dbOrder);
            }
            else
            {
                await _context.orders.AddAsync(dbOrder);
            }

            await _context.SaveChangesAsync();

            var dbOrders = _context.orders.Where(order => !order.is_book && order.owner_id == userId).ToList();
            var OrdersGetDto = dbOrders.Select(x => _mapper.Map<OrderGetDto>(x)).ToList();
            response.result = OrdersGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<OrderItemsGetDto>>> createOrderItems(OrderItemsCreateDto newOrderItem)
        {
            var response = new ServiceResponse<List<OrderItemsGetDto>>();
            var dbOrderItem = _mapper.Map<OrderItem>(newOrderItem);
            var userId = _tokenService.getUserId();
            dbOrderItem.owner_id = userId;
            await _context.order_items.AddAsync(dbOrderItem);
            await _context.SaveChangesAsync();
            var dbOrderItems = _context.order_items.Where(orderItem => orderItem.owner_id == userId).ToList();
            var orderItemsDto = dbOrderItems.Select(x => _mapper.Map<OrderItemsGetDto>(x)).ToList();
            response.result = orderItemsDto;
            return response;
        }

        public async Task<ServiceResponse<List<BookGetDto>>> getBooksByParams(int? id)
        {
            var response = new ServiceResponse<List<BookGetDto>>();
            var userId = _tokenService.getUserId();
            var dbBooks = _context.orders.Where(order => 
            order.is_book && 
            order.owner_id == userId &&
            (string.IsNullOrEmpty(id.ToString()) || order.id == id)).ToList();

            var bookGetDto = dbBooks.Select(x => _mapper.Map<BookGetDto>(x)).ToList();
            response.result = bookGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> getOrdersByParams(int? id)
        {
            var response = new ServiceResponse<List<OrderGetDto>>();
            var userId = _tokenService.getUserId();
            var dbOrders = await _context.orders.Where(order =>
            !order.is_book &&
            order.owner_id == userId &&
            (string.IsNullOrEmpty(id.ToString()) || order.id == id)).ToListAsync();

            var ordersGetDto = dbOrders.Select(x => _mapper.Map<OrderGetDto>(x)).ToList();
            response.result = ordersGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<ProductsGetDto>>> getProductsByParams([FromQuery] ProductsRequest request)
        {
            var response = new ServiceResponse<List<ProductsGetDto>>();
            var dbProducts = await _context.products.Where(product =>
                (string.IsNullOrEmpty(request.id.ToString()) || product.id.ToString() == request.id.ToString()) &&
                (string.IsNullOrEmpty(request.productTypeId.ToString()) || product.product_type_id.ToString() == request.productTypeId.ToString()) &&
                (string.IsNullOrEmpty(request.onSale.ToString()) || product.on_sale.ToString() == request.onSale.ToString()) &&
                (string.IsNullOrEmpty(request.sellingCost.ToString()) || product.selling_cost.ToString() == request.sellingCost.ToString()) &&
                (string.IsNullOrEmpty(request.modelId.ToString()) || product.model_id.ToString() == request.modelId.ToString())
                ).ToListAsync();

            var productsDto = dbProducts.Select(x => _mapper.Map<ProductsGetDto>(x)).ToList();
            response.result = productsDto;
            return response;
        }

        public async Task<ServiceResponse<List<BookGetDto>>> removeBookById(int id)
        {
            var response = new ServiceResponse<List<BookGetDto>>();
            var dbBook = await _context.orders.FirstOrDefaultAsync(order => order.id == id);
            if(dbBook == null)
            {
                response.success = false;
                response.message = "book Doesnot exists";
                return response;
            }
            _context.orders.Remove(dbBook);
            await _context.SaveChangesAsync();

            var userId = _tokenService.getUserId();
            var dbBooks = _context.orders.Where(order => order.is_book && order.owner_id == userId).ToList();

            var bookGetDto = dbBooks.Select(x => _mapper.Map<BookGetDto>(x)).ToList();
            response.result = bookGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> removeOrderById(int id)
        {
            var response = new ServiceResponse<List<OrderGetDto>>();
            var dbOrder = await _context.orders.FirstOrDefaultAsync(order => order.id == id);
            if (dbOrder == null)
            {
                response.success = false;
                response.message = "dbOrder Doesnot exists";
                return response;
            }
            _context.orders.Remove(dbOrder);
            await _context.SaveChangesAsync();

            var userId = _tokenService.getUserId();
            var dbOrders = _context.orders.Where(order => !order.is_book && order.owner_id == userId).ToList();

            var ordersGetDto = dbOrders.Select(x => _mapper.Map<OrderGetDto>(x)).ToList();
            response.result = ordersGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<OrderItemsGetDto>>> removeOrderItemsById(int id)
        {
            var response = new ServiceResponse<List<OrderItemsGetDto>>();
            var dbOrderItem = await _context.order_items.FirstOrDefaultAsync(orderItem => orderItem.id == id);
            if (dbOrderItem == null)
            {
                response.success = false;
                response.message = "dbOrderItems Doesnot exists";
                return response;
            }
            await _context.orders
                .Where(order => 
                    order.order_items_id == id && 
                    order.owner_id == _tokenService.getUserId())
                .ForEachAsync(async order =>
                {
                    _context.orders.Remove(order);
                });

            await _context.SaveChangesAsync();
            _context.order_items.Remove(dbOrderItem);
            await _context.SaveChangesAsync();

            var userId = _tokenService.getUserId();
            var dbOrderItems = _context.order_items.Where(order => order.owner_id == userId).ToList();

            var orderItemsGetDto = dbOrderItems.Select(x => _mapper.Map<OrderItemsGetDto>(x)).ToList();
            response.result = orderItemsGetDto;
            return response;
        }

        public async Task<ServiceResponse<List<OrderItemsGetDto>>> SubmitOrderItemsById(int id)
        {
            var response = new ServiceResponse<List<OrderItemsGetDto>>();
            var dbOrderItem = await _context.order_items.FirstOrDefaultAsync(x => x.id == id);
            if(dbOrderItem == null)
            {
                response.success = false;
                response.message = "can not find Order items";
                return response;
            }

            dbOrderItem.end_date = DateTime.Now;
            dbOrderItem.is_active = false;
            _context.order_items.Update(dbOrderItem);

            var ordersInSubmittedOrderItems = _context.orders
                .Where(order=>order.order_items_id == id)
                .ForEachAsync(order =>
                {
                    order.active = false;
                    order.end_date = DateTime.Now;
                    _context.orders.Update(order);
                });

            await _context.SaveChangesAsync();
            var dbOrderItems = await _context.order_items.Where(orderItems => orderItems.owner_id == _tokenService.getUserId()).ToListAsync();
            var orderItemsDto = dbOrderItems.Select(x => _mapper.Map<OrderItemsGetDto>(x)).ToList();
            response.result = orderItemsDto;
            return response;
        }

        public async Task<ServiceResponse<List<ProductsGetDto>>> updateProduct(ProductUpdateDto updatedProduct)
        {
            var response = new ServiceResponse<List<ProductsGetDto>>();
            var dbProduct = await _context.products.FirstOrDefaultAsync(x => updatedProduct.id == x.id);
            
            if(dbProduct == null)
            {
                response.success = false;
                response.message = "product not found";
                return response;
            }

            if(updatedProduct.productTypeId != null)
                dbProduct.product_type_id = (int)updatedProduct.productTypeId;
            if(!string.IsNullOrEmpty(updatedProduct.features))
                dbProduct.features = updatedProduct.features;
            if(updatedProduct.onSale != null)
                dbProduct.on_sale = (bool)updatedProduct.onSale;
            if(updatedProduct.quantity != null)
                dbProduct.quantity = (int)updatedProduct.quantity;
            if (updatedProduct.sellingCost != null)
                dbProduct.selling_cost = (int)updatedProduct.sellingCost;
            if (updatedProduct.buyingCost != null)
                dbProduct.buying_cost = (int)updatedProduct.buyingCost;
            if (updatedProduct.initialQuantity != null)
                dbProduct.initial_quantity = (int)updatedProduct.initialQuantity;
            if (!string.IsNullOrEmpty(updatedProduct.img))
                dbProduct.img = updatedProduct.img;
            if (updatedProduct.modelId != null)
                dbProduct.model_id = (int)updatedProduct.modelId;
    

            _context.products.Update(dbProduct);
            await _context.SaveChangesAsync();
             
            var dbProducts = await _context.products.ToListAsync();
            var productsDto = dbProducts.Select(x => _mapper.Map<ProductsGetDto>(x)).ToList();
            response.result = productsDto;
            return response;

        }
    }
}
