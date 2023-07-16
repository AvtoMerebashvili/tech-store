namespace tech_store.DbModels.Auth
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Phone { get; set; }
        public string TargetName { get; set; }
        public string TargetSurname { get; set; }
        public int UserID { get; set; }
    }
}
