namespace tech_store.DbModels.Products
{
    public class Order
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public int BookId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int OrderItemsId { get; set; }
        public bool PassInBranch { get; set; }
        public int DeliveryAddressId { get; set; }
        public bool Active { get; set; }

    }
}
