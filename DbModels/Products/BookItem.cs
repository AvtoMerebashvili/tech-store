using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Products
{
    public class BookItem : ValueBase
    {
        public int owner_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
