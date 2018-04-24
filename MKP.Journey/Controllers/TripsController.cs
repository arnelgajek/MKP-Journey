using MKP.Journey.DataAccess;
using MKP.Journey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MKP.Journey.Controllers
{
    public class TripsController : ApiController
    {

        private DefaultDataContext db = new DefaultDataContext();

        [HttpGet]
        public IEnumerable<Trip> GetTrips()
        {
            return db.Trips;
        }

        [HttpPost]
        public IHttpActionResult PostTrips(Trip trip)
        {
            db.Trips.Add(trip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Trips",
                id = trip.TripId
            }, trip);
        }
    }
}
