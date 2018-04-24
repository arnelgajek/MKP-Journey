﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MKP.Journey.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string RegNumber { get; set; }

        public Status Status { get; set; }

        public bool StandardVehicle { get; set; }
    }
}