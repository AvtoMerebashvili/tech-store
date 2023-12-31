﻿using tech_store.DbModels.Products;

namespace tech_store.DbModels.Auth
{
    public class Address : AddressRelations
    {
        public int id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string postal_code { get; set; }
        public int phone { get; set; }
        public string target_name { get; set; }
        public string target_surname { get; set; }
        public int user_id { get; set; }
    }

    public class AddressRelations
    {
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
