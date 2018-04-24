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
    //[Authorize] Genom aktivering av denna så låser man tillgången till API för vehicle:
    public class VehicleController : ApiController
    {

        private DefaultDataContext db = new DefaultDataContext();

        [HttpGet]
        public IEnumerable<Vehicle> GetVehicles()
        {
            return db.Vehicles;
        }

        [HttpPost]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Vehicle",
                id = vehicle.VehicleId
            }, vehicle);
        }

        public HttpResponseMessage Put(int id, [FromBody]Vehicle vehicle)
        {
            try
            {
                var setStatus = db.Vehicles.FirstOrDefault(x => x.VehicleId == id);

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

        [HttpDelete]

        public IHttpActionResult DeleteVehicle(int id)
        {
            var vehicle = db.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            return Ok(vehicle);
        }
    }
}


