using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKP.Journey.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        
        [Required]
        public string RegNumber { get; set; }

        public Status Status { get; set; }

        public bool StandardVehicle { get; set; }

    }
}