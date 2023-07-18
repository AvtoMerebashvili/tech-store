﻿using tech_store.DbModels.Auth;

namespace tech_store.DbModels.Products
{
    public class Order : OrderRelations
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public bool is_book { get; set; }
        public DateTime create_date { get; set; }
        public DateTime end_date { get; set; }
        public DateTime expiration_date { get; set; }
        public int order_items_id { get; set; }
        public bool pass_in_branch { get; set; }
        public int delivery_address_id { get; set; }
        public bool active { get; set; }

    }
    public class OrderRelations
    {
        public Product Product { get; set; }
        public OrderItem OrderItem { get; set; }
        public Address Address { get; set; }
    }
}
