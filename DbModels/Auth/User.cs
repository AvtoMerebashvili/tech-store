using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Auth
{
    public class User : ValueBase
    {   
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string surname { get; set; }
        public int role_id { get; set; }
    }
}
