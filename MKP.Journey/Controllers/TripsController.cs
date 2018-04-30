using MKP.Journey.DataAccess;
using MKP.Journey.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MKP.Journey.Controllers
{
    //[Authorize]
    [RoutePrefix("api/trips")]
    public class TripsController : ApiController
    {

        private DefaultDataContext db = new DefaultDataContext();

        [Route("")]
        public IQueryable<Trip> GetTrips()
        {
            return db.Trips.Include(x => x.Vehicle);
        }

        // GET: api/trips/5
        [Route("{Id}")]
        [ResponseType(typeof(Trip))]
        public async Task<IHttpActionResult> GetTrip(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // PUT: api/trips/5
        [Route("")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrip(int id, Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.Id)
            {
                return BadRequest();
            }

            db.Entry(trip).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/trips
        [Route("")]
        [ResponseType(typeof(Trip))]
        public async Task<IHttpActionResult> PostTrip(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trips.Add(trip);
            await db.SaveChangesAsync();

            return Ok(trip);
        }

        // DELETE: api/trips/5
        [ResponseType(typeof(Trip))]
        public async Task<IHttpActionResult> DeleteTrip(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            db.Trips.Remove(trip);
            await db.SaveChangesAsync();

            return Ok(trip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TripExists(int id)
        {
            return db.Trips.Count(e => e.Id == id) > 0;
        }
    }

    //[Route("")]
    //[HttpGet]
    //public IEnumerable<Trip> GetAllTrips()
    //{
    //    return db.Trips;
    //}

    //[Route("{Id}")]
    //[HttpGet]
    //public Trip GetUniqueTrip(int id)
    //{
    //    return db.Trips.FirstOrDefault(t => t.Id == id);
    //}

    //[Route("")]
    //[HttpPost]
    //public IHttpActionResult PostTrips(Trip trip)
    //{
    //    db.Trips.Add(trip);
    //    db.SaveChanges();

    //    return CreatedAtRoute("DefaultApi", new
    //    {
    //        controller = "Trips",
    //        id = trip.Id
    //    }, trip);
    //}
}

