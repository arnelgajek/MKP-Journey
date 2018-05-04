using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MKP.Journey.Models;
using MKP.Journey.DataAccess;
using System.Data.Entity;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Journey.Controllers
{
    [Authorize]
    [RoutePrefix("api/vehicle")]
    public class VehicleController : ApiController
    {

        private DefaultDataContext db = new DefaultDataContext();

        [Route("")]
        public IQueryable<Vehicle> GetVehicle()
        {
            return db.Vehicles;
        }

        // GET: api/vehicle/5
        [Route("{Id}")]
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> GetVehicle(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // PUT: api/vehicle/5
        [Route("{Id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (vehicle.StandardVehicle == true)
            {
                List<Vehicle> vehicles = db.Vehicles.Where(x => x.StandardVehicle == true).ToList();
                vehicles.Select(x => { x.StandardVehicle = false; return x; }).ToList();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/vehicle
        [Route("")]
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();

            return Ok(vehicle);
        }

        // DELETE: api/vehicle/5
        [Route("{Id}")]
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> DeleteVehicle(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Count(e => e.Id == id) > 0;
        }
    }
}



