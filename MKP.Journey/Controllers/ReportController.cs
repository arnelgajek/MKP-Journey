using MKP.Journey.Helpers;
using MKP.Journey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MKP.Journey.Controllers
{
    public class ReportController : ApiController
    {
        // POST: api/reports/generate
        [Route("api/reports/generate")]
        [HttpPost]
        public IHttpActionResult GeneratePdfUrl(DownloadModel downloadModel)
        {
            var url = PdfHelper.GetVehicleTripsPdfUrl(downloadModel);
            return Ok(url);
        }

        //POST: api/chart
        [Route("api/chart")]
        [HttpPost]
        public IHttpActionResult GenerateChart(DownloadModel selection)
        {
            var tripsController = new TripsController();
            //var vehicleTrips = tripsController.GetTripsByDates(selection.VehicleId, selection.FromDate, selection.ToDate);
            return Ok(/*vehicleTrips*/);
        }
    }
}
