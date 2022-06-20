using Microsoft.EntityFrameworkCore;

namespace ShopASPNet.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
