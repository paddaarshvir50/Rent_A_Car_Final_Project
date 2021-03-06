using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_Final_Project.Models
{
    //A customer
    public class Customer
    {
        //Customer id
        public int Id { get; set; }

        //Email of customer.
        public string Email { get; set; }

        //Csutomer name.
        public string Name { get; set; }

        //Csutomer phone number.
        public string ContactNumber { get; set; }
    }
}
