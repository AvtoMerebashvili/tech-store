namespace tech_store.Dtos.Books
{
    public class BookGetDto
    {
        public int id { get; set; }
        public string productId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
