namespace tech_store.Dtos.Address
{
    public class AddressAddDto
    {
        public int id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string postalCode { get; set; }
        public int phone { get; set; }
        public string targetName { get; set; }
        public string? targetSurname { get; set; }
        //public int userId { get; set; }
    }
}
