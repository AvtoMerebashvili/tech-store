using tech_store.DbModels.Products;

namespace tech_store.DbModels.Auth
{
    public class User : UserRelations
    {   
        public string username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string surname { get; set; }
        public int role_id { get; set; }
 
    }

    public class UserRelations : ValueBase
    {
        public Role Role { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
