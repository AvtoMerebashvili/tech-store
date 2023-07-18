using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Catalogs
{
    public class Country : ValueBase
    {
        public string code { get; set; }
        public List<City> Cities { get; set; }
    }
}
