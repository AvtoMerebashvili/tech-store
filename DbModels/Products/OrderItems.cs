namespace tech_store.DbModels.Products
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BookItemsId { get; set; }    

    }
}
