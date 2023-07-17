namespace tech_store.DbModels.Products
{
    public class BookItem
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public string name { get; set; }
        public DateTime create_date { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
