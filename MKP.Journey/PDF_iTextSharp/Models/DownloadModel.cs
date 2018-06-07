using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MKP.Journey.Models
{
    public class DownloadModel
    {
        public int VehicleId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}