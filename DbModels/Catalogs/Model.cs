using tech_store.DbModels.Products;

namespace tech_store.DbModels.Catalogs
{
    public class Model : ValueBase
    {
        public int brand_id{ get; set; }
        public Brand Brand { get; set; } 
        public List<Product> Products {get;set;}  
    }
}
