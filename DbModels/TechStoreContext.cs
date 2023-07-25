using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using tech_store.DbModels.Auth;
using tech_store.DbModels.Catalogs;
using tech_store.DbModels.Products;

namespace tech_store.DbModels
{
    public class TechStoreContext : DbContext
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options)
        {

        }
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MBFL1BV;Database=tech_market_app;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            this.createUsersTable(modelBuilder);
            this.createRolesTable(modelBuilder);
            this.createAddressesTable(modelBuilder);
            this.createBrandsTable(modelBuilder);
            this.createModelsTable(modelBuilder);
            this.createCountriesTable(modelBuilder);
            this.createCitiesTable(modelBuilder);
            this.createProductTypesTable(modelBuilder);
            this.createOrdersTable(modelBuilder);
            this.createOrderItemsTable(modelBuilder);
            this.createProductsTable(modelBuilder);
        }

        // AUTH
        private void createUsersTable(ModelBuilder modelBuilder){     
            modelBuilder.Entity<User>().HasKey(e => e.id);
            modelBuilder.Entity<User>().Property(e => e.name).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.surname).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.username).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.passwordHash).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.passwordSalt).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.role_id).IsRequired();
            modelBuilder.Entity<User>().HasOne(e=>e.Address).WithOne(e=>e.User).HasForeignKey<Address>(e => e.user_id);
        }

        private void createRolesTable(ModelBuilder modelBuilder){     
            modelBuilder.Entity<Role>().HasKey(e => e.id);
            modelBuilder.Entity<Role>().Property(e => e.id).ValueGeneratedNever();
            modelBuilder.Entity<Role>().Property(e => e.name).IsRequired();
            modelBuilder.Entity<Role>().HasMany(e => e.Users).WithOne(e => e.Role).HasForeignKey(e => e.role_id);
        }

        private void createAddressesTable(ModelBuilder modelBuilder){     
            modelBuilder.Entity<Address>().HasKey(e => e.id);
            modelBuilder.Entity<Address>().Property(e => e.country).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.city).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.street).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.postal_code).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.phone).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.phone).HasMaxLength(12);
            modelBuilder.Entity<Address>().Property(e => e.target_name).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.phone).IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.user_id).IsRequired();
        }

        // CATALOG
        private void createBrandsTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<Brand>().HasKey(e=>e.id);
            modelBuilder.Entity<Brand>().Property(e=>e.id).ValueGeneratedNever();
            modelBuilder.Entity<Brand>().Property(e=>e.name).IsRequired();    
            modelBuilder.Entity<Brand>().HasMany(e=>e.Models).WithOne(e=>e.Brand).HasForeignKey(e=>e.brand_id);
        }

        private void createModelsTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<Model>().HasKey(e=>e.id);
            modelBuilder.Entity<Model>().Property(e=>e.id).ValueGeneratedNever();
            modelBuilder.Entity<Model>().Property(e=>e.name).IsRequired();
            modelBuilder.Entity<Model>().Property(e=>e.brand_id).IsRequired();           
        }
    
        private void createCountriesTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<Country>().HasKey(e=>e.id);
            modelBuilder.Entity<Country>().Property(e=>e.id).ValueGeneratedNever();
            modelBuilder.Entity<Country>().Property(e=>e.name).IsRequired();
            modelBuilder.Entity<Country>().HasMany(e=>e.Cities).WithOne(e=>e.Country).HasForeignKey(e=>e.country_id);
        }
    
        private void createCitiesTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<City>().HasKey(e=>e.id);
            modelBuilder.Entity<City>().Property(e=>e.id).ValueGeneratedNever();
            modelBuilder.Entity<City>().Property(e=>e.name).IsRequired();
            modelBuilder.Entity<City>().Property(e=>e.country_id).IsRequired();
            modelBuilder.Entity<City>().HasOne(e=>e.Country).WithMany(e=>e.Cities).HasForeignKey(e=>e.country_id);
        }
    
        private void createProductTypesTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<ProductType>().HasKey(e=>e.id);
            modelBuilder.Entity<ProductType>().Property(e => e.id).ValueGeneratedNever();
            modelBuilder.Entity<ProductType>().Property(e=>e.name).IsRequired();
        }
    
        // PRODUCTS 
        private void createOrdersTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<Order>().HasKey(e=>e.id);
            modelBuilder.Entity<Order>().Property(e=>e.product_id).IsRequired();
            modelBuilder.Entity<Order>().Property(e=>e.is_book).IsRequired();
            modelBuilder.Entity<Order>().Property(e=>e.create_date).IsRequired();
            modelBuilder.Entity<Order>().Property(e=>e.create_date).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Order>().Property(e=>e.active).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.active).HasDefaultValue(true);
            modelBuilder.Entity<Order>().HasOne(e=>e.Product).WithMany(e=>e.Orders).HasForeignKey(e=>e.product_id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(e=>e.OrderItem).WithMany(e=>e.Orders).HasForeignKey(e=>e.order_items_id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(e=>e.Address).WithMany(e=>e.Orders).HasForeignKey(e=>e.delivery_address_id);
            modelBuilder.Entity<Order>().HasOne(e=>e.user).WithMany(e=>e.Orders).HasForeignKey(e=>e.owner_id).OnDelete(DeleteBehavior.NoAction);

        }

        private void createOrderItemsTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<OrderItem>().HasKey(e=>e.id);
            modelBuilder.Entity<OrderItem>().Property(e=>e.name).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e=>e.owner_id).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e=>e.create_date).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e=>e.create_date).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<OrderItem>().Property(e=>e.end_date).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e=>e.is_active).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e=>e.is_active).HasDefaultValue(true);
            modelBuilder.Entity<OrderItem>().HasOne(e=>e.User).WithMany(e=>e.OrderItems).HasForeignKey(e=>e.owner_id);
            modelBuilder.Entity<OrderItem>().HasMany(e=>e.Orders).WithOne(e=>e.OrderItem).HasForeignKey(e=>e.order_items_id).OnDelete(DeleteBehavior.NoAction);
        }
    
        private void createProductsTable(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasKey(e=>e.id);
            modelBuilder.Entity<Product>().Property(e=>e.name).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.on_sale).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.quantity).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.initial_quantity).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.selling_cost).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.buying_cost).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.model_id).IsRequired();
            modelBuilder.Entity<Product>().Property(e=>e.creator_id).IsRequired();
            modelBuilder.Entity<Product>().HasMany(e=>e.Orders).WithOne(e=>e.Product).HasForeignKey(e=>e.product_id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasOne(e=>e.ProductType).WithMany(e=>e.Products).HasForeignKey(e=>e.product_type_id);
            modelBuilder.Entity<Product>().HasOne(e=>e.Model).WithMany(e=>e.Products).HasForeignKey(e=>e.product_type_id);
            modelBuilder.Entity<Product>().HasOne(e=>e.User).WithMany(e=>e.Products).HasForeignKey(e=>e.creator_id);
        }
    }
}
