using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MKP.Journey.Models;
using MKP.Journey.DataAccess;
using System.Data.Entity;

namespace Journey.Controllers
{
    //[Authorize]
    [RoutePrefix("api/vehicle")]
    public class VehicleController : ApiController
    {

        private DefaultDataContext db = new DefaultDataContext();

        [Route("")]
        [HttpGet]
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return db.Vehicles.Include(t => t.Trips).OrderByDescending(v => v.StandardVehicle).ThenBy(v => v.Status);
        }

        [Route("{Id}")]
        [HttpGet]
        public Vehicle GetUniqueVehicle(int id)
        {
            return db.Vehicles.Include(t => t.Trips).FirstOrDefault(v => v.Id == id);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Vehicle",
                id = vehicle.Id
            }, vehicle);
        }

        [Route("{Id}")]
        public HttpResponseMessage Put(int id, [FromBody]Vehicle vehicle)
        {
            try
            {
                var setStatus = db.Vehicles.FirstOrDefault(x => x.Id == id);

                if (setStatus == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle with id = " + id.ToString() + "not found to update");
                }
                else
                {
                    setStatus.Status = vehicle.Status;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, setStatus);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var vehicle = db.Vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            return Ok(vehicle);
        }

        [Route("{Id}/trips")]
        public IEnumerable<Trip> GetVehicleTrips(int id)
        {
                return db.Trips;
        }

    }
}


