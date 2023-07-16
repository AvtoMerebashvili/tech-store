namespace tech_store.DbModels.Catalogs
{
    public class City
    {
        public int Id { get; set; }
        public string NameGeo { get; set; }
        public string NameLat { get; set; }
        public int CountryId { get; set; }
    }
}
