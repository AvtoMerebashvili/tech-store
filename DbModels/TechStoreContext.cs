using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using tech_store.DbModels.Auth;
using tech_store.DbModels.Catalogs;
using tech_store.DbModels.Products;

namespace tech_store.DbModels
{
    public class TechStoreContext : DbContext
    {
        //public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options)
        //{
        //}
        //Auth
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Address> addresses { get; set; }    
        //Catalogs
        public DbSet<Brand> brands { get; set; }    
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Model> models { get; set; }    
        public DbSet<ProductType> product_types { get; set; }
        //Products
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> order_items { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<BookItem> book_items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MBFL1BV;Database=tech_market;TrustServerCertificate=True;Trusted_Connection=True;");
        }

    }
}
