using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Catalogs
{
    public class City : ValueBase
    {
        public int country_id { get; set; }
    }
}
