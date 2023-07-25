namespace tech_store.Dtos.OrderItems
{
    public class OrderItemsGetDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
        public List<OrderGetDto> includedOrders { get; set; }
    }
}
