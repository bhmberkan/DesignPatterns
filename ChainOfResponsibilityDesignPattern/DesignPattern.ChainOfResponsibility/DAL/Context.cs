using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-AV1UIG0; initial catalog=DesignPattern1; integrated Security=true;TrustServerCertificate=Yes;");
        }

        public DbSet<CustomerProcess> customerProcesses { get; set; }

      
    }
}
