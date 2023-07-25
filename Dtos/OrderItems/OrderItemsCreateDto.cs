namespace tech_store.Dtos.OrderItems
{
    public class OrderItemsCreateDto
    {
        public string name { get; set; }
        public bool isActive { get; set; } = true;
    }
}
