using tech_store.DbModels.Auth;
using tech_store.DbModels.Catalogs;

namespace tech_store.DbModels.Products
{
    public class Product : ProductRelations
    {
        public int product_type_id { get; set; }
        public string features { get; set; }
        public bool on_sale { get; set; }
        public int quantity { get; set; }
        public int selling_cost { get; set;}
        public int buying_cost { get; set;}
        public int initial_quantity { get; set; }
        public string img { get; set; }
        public int model_id { get; set; }
        public int creator_id { get; set; }

    }

    public class ProductRelations : ValueBase
    {
        public List<Order> Orders { get; set; }
        public ProductType ProductType { get; set; }
        public Model Model { get; set; }
        public User User { get; set; }
    }
}
