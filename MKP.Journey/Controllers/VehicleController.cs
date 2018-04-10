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

        [HttpPut]
        public IHttpActionResult PutVehicle(Vehicle vehicle)
        {
            if (!db.Vehicles.Any(v => v.VehicleId.Equals(vehicle.VehicleId)))
            {
                return NotFound();
            }

            db.Entry(vehicle).State = EntityState.Modified;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Vehicle",
                id = vehicle.VehicleId
            }, vehicle);
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


