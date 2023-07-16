namespace tech_store.DbModels.Products
{
    public class BookItems
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public required string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
