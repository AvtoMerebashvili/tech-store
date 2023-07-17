namespace tech_store.DbModels.Products
{
    public class Product
    {
        public int id { get; set; }
        public int product_type_id { get; set; }
        public required string name { get; set; }
        public required string features { get; set; }
        public bool on_sale { get; set; }
        public int quantity { get; set; }
        public int selling_cost { get; set;}
        public int buying_cost { get; set;}
        public int initial_quantity { get; set; }
        public string img { get; set; }
        public int brand_id { get; set; }
        public int creator_id { get; set; }
    }
}
