using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Products
{
    public class OrderItem : ValueBase
    {
        public int owner_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime end_date { get; set; }
        public int book_item_id { get; set; }    

    }
}
