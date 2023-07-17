using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Catalogs
{
    public class City : CatalogBase
    {
        public int country_id { get; set; }
    }
}
