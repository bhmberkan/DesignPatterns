using Microsoft.EntityFrameworkCore;

namespace DesignPatter.Composite.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-AV1UIG0; initial catalog=DesignPattern7; integrated Security=true;TrustServerCertificate=Yes;");
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
