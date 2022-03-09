using Microsoft.EntityFrameworkCore;

namespace ShopASPNet.Model.ShopModel
{
    public class ApplicationContextShop : DbContext
    {
        public DbSet<Category> Categorys { get; set; }

        public DbSet<Product> Products { get; set; }


        public ApplicationContextShop(DbContextOptions<ApplicationContextShop> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
