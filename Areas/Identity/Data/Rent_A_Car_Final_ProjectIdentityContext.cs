using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rent_A_Car_Final_Project.Models
{
    public class Rent_A_Car_Final_ProjectIdentityContext : IdentityDbContext<IdentityUser>
    {
        public Rent_A_Car_Final_ProjectIdentityContext(DbContextOptions<Rent_A_Car_Final_ProjectIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
