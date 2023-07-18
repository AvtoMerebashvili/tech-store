namespace tech_store.Dtos.Orders
{
    public class OrderGetDto
    {
        public int id { get; set; }
        public int productId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime endDate { get; set; }
        public int orderItemsId { get; set; }
        public bool passInBranch { get; set; }
        public int deliveryAddressId { get; set; }
        public bool active { get; set; }
    }
}
