namespace tech_store.Dtos.Products
{
    public class ProductAddDto
    {
        public int productTypeId { get; set; }
        public string name { get; set; }
        public string features { get; set; }
        public bool onSale { get; set; }
        public int quantity { get; set; }
        public int sellingCost { get; set; }
        public int buyingCost { get; set; }
        public int initialQuantity { get; set; }
        public string img { get; set; }
        public int modelId { get; set; }
        public int creatorId { get; set; }
    }
}
