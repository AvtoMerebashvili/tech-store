namespace tech_store.DbModels.Products
{
    public class Book
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public required DateTime CreateDate { get; set; }
        public required DateTime ExpirationDate { get; set; }
        public int BookItemsId { get; set; }

    }
}
