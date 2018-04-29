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
    //[Authorize]
    [RoutePrefix("api/trips")]
    public class TripsController : ApiController
    {

        private DefaultDataContext db = new DefaultDataContext();

        [Route("")]
        [HttpGet]
        public IEnumerable<Trip> GetAllTrips()
        {
            return db.Trips;
        }

        [Route("{Id}")]
        [HttpGet]
        public Trip GetUniqueTrip(int id)
        {
            return db.Trips.FirstOrDefault(t => t.Id == id);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostTrips(Trip trip)
        {
            db.Trips.Add(trip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Trips",
                id = trip.Id
            }, trip);
        }
    }
}
