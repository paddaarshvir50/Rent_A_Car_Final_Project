using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_Final_Project.Models
{
    //Booking information.
    public class Booking
    {
        //booking id
        public int Id { get; set; }

        //Customer id foreign key
        public int CustomerId { get; set; }

        //CarId id foreign key
        public int CarId { get; set; }

        //Customer.
        public Customer Customer { get; set; }

        //Car
        public Car Car { get; set; }



    }
}
