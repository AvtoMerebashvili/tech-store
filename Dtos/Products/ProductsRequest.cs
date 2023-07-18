namespace tech_store.Dtos.Products
{
    public class ProductsRequest
    {
        public int? id { get; set; }
        public int? productTypeId { get; set; }
        public bool? onSale { get; set; }
        public int? sellingCost { get; set; }
        public int? modelId { get; set; }

    }
}
