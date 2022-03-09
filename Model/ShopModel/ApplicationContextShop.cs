using Microsoft.EntityFrameworkCore;

namespace ShopASPNet.Model.ShopModel
{
    public class ApplicationContextShop : DbContext
    {
        public ApplicationContextShop(DbContextOptions<ApplicationContextShop> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
