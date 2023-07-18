using tech_store.DbModels.BaseDbModels;

namespace tech_store.DbModels.Auth
{
    public class Role : ValueBase
    {
        public List<User> Users { get; set; }
    }
}
