using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Decorator.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-AV1UIG0; initial catalog=DesignPattern11; integrated Security=true;TrustServerCertificate=Yes;");
        }

        public DbSet<Message> messages { get; set; }
        public DbSet<Notifier> notifiers{ get; set; }

    }
}
