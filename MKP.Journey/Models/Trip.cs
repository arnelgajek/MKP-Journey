using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MKP.Journey.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public int KmStart { get; set; }

        public int KmStop { get; set; }

        public string StartAddress { get; set; }

        public string StopDestination { get; set; }

        public string Arrend { get; set; }

        public string Notes { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public Trip()
        {
            Vehicles = new List<Vehicle>();
        }

    }
}