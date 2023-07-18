using tech_store.DbModels.Auth;
using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Products
{
    public class OrderItem : OrderItemRelations
    {
        public int owner_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime end_date { get; set; }

    }

    public class OrderItemRelations : ValueBase{
        public List<Order> Orders {get; set;} 
        public User User { get; set; }
    }
}
