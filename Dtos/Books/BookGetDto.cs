namespace tech_store.Dtos.Books
{
    public class BookGetDto
    {
        public int id { get; set; }
        public string productId { get; set; }
        public DateTime create_date { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
