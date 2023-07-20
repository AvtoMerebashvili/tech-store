namespace tech_store.Dtos.Orders
{
    public class OrderItemsGetDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<OrderGetDto> includedOrders { get; set; }
    }
}
