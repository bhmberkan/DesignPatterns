using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Observer.DAL
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-AV1UIG0; initial catalog=DesignPattern4; integrated Security=true;TrustServerCertificate=Yes;");
        }

        public DbSet<WelcomeMessage> welcomeMessages { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<UserProcess> userProcesses { get; set; }
    }
}
