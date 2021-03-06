using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent_A_Car_Final_Project.Models;

[assembly: HostingStartup(typeof(Rent_A_Car_Final_Project.Areas.Identity.IdentityHostingStartup))]
namespace Rent_A_Car_Final_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Rent_A_Car_Final_ProjectIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Rent_A_Car_Final_ProjectIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                   
                    .AddEntityFrameworkStores<Rent_A_Car_Final_ProjectIdentityContext>();
            });
        }
    }
}