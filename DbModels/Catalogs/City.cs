﻿namespace tech_store.DbModels.Catalogs
{
    public class City : ValueBase
    {
        public int country_id { get; set; }
        public Country Country { get; set; }
    }
}
