using Microsoft.EntityFrameworkCore;

namespace tech_store.DbModels
{
    public class TechStoreContext : DbContext
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options)
        {

        }
    }
}
