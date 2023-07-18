using tech_store.DbModels.BaseDbModels;
using tech_store.DbModels.Products;

namespace tech_store.DbModels.Catalogs
{
    public class ProductType : ValueBase
    {
        public List<Product> Products { get; set; }
    }
}
