using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_Final_Project.Models
{
    //Car info.
    public class Car
    {
        //Car id
        public int Id { get; set; }

        //Car plate number
        public string  RegistrationId { get; set; }

        //Car make
        public string Make { get; set; }

        //car model
        public string Model { get; set; }

        //Car rent per day.
        public decimal RentPricePerDay { get; set; }

        public bool Booked { get; set; }

        //Car photo url
        public string Picture { get; set; }

        //Car photo stream 
        [NotMapped]
        public IFormFile PictureFile { get; set; }

    }
}
