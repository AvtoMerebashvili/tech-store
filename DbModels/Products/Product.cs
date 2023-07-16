namespace tech_store.DbModels.Products
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public required string Name { get; set; }
        public required string Features { get; set; }
        public bool OnSale { get; set; }
        public int Quantity { get; set; }
        public int SellingCost { get; set;}
        public int BuyingCost { get; set;}
        public int InitialQuantity { get; set; }
        public string Img { get; set; }
        public int BrandId { get; set; }
        public int CreatorId { get; set; }
    }
}
