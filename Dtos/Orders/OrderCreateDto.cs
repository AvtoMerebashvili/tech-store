namespace tech_store.Dtos.Orders
{
    public class OrderCreateDto
    {
        public int productId { get; set; }
        public bool isBook = false;
     
        public int? orderItemsId { get; set; }
        public bool passInBranch { get; set; }
        public int? deliveryAddressId { get; set; }
    }
}
