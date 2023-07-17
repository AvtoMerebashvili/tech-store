namespace tech_store.DbModels.Products
{
    public class Order
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public int product_id { get; set; }
        public int book_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime end_date { get; set; }
        public int order_item_id { get; set; }
        public bool pass_in_branch { get; set; }
        public int delivery_address_id { get; set; }
        public bool active { get; set; }

    }
}
