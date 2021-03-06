using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Final_Project.Models;

namespace Rent_A_Car_Final_Project.Models
{
    //Maps the model objects to database records.
    public class Rent_A_Car_Final_ProjectDataContext : DbContext
    {
        public Rent_A_Car_Final_ProjectDataContext (DbContextOptions<Rent_A_Car_Final_ProjectDataContext> options)
            : base(options)
        {
        }

        public DbSet<Rent_A_Car_Final_Project.Models.Booking> Booking { get; set; }

        public DbSet<Rent_A_Car_Final_Project.Models.Car> Car { get; set; }

        public DbSet<Rent_A_Car_Final_Project.Models.Customer> Customer { get; set; }
    }
}
