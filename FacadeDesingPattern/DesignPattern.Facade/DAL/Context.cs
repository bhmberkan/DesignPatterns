using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Facade.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-AV1UIG0; initial catalog=DesignPattern10; integrated Security=true;TrustServerCertificate=Yes;");
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }
}
