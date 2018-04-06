using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServiceInfinity.Models;

namespace WebServiceInfinity.Controllers.Api
{
    public class ViaLacteaController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/ViaLactea
        public IQueryable<ViaLactea> GetViaLacteas()
        {
            return db.ViaLacteas.Include(xx=>xx.Nebulosas);
        }

        // GET: api/ViaLactea/5
        [ResponseType(typeof(ViaLactea))]
        public IHttpActionResult GetViaLactea(int id)
        {
            ViaLactea viaLactea = db.ViaLacteas.Include(xx=>xx.Nebulosas).FirstOrDefault(x=>x.id==id);
            if (viaLactea == null)
            {
                return NotFound();
            }

            return Ok(viaLactea);
        }

        // PUT: api/ViaLactea/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViaLactea(int id, ViaLactea viaLactea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viaLactea.id)
            {
                return BadRequest();
            }

            db.Entry(viaLactea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViaLacteaExists(id))
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

        // POST: api/ViaLactea
        [ResponseType(typeof(ViaLactea))]
        public IHttpActionResult PostViaLactea(ViaLactea viaLactea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViaLacteas.Add(viaLactea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viaLactea.id }, viaLactea);
        }

        // DELETE: api/ViaLactea/5
        [ResponseType(typeof(ViaLactea))]
        public IHttpActionResult DeleteViaLactea(int id)
        {
            ViaLactea viaLactea = db.ViaLacteas.Find(id);
            if (viaLactea == null)
            {
                return NotFound();
            }

            db.ViaLacteas.Remove(viaLactea);
            db.SaveChanges();

            return Ok(viaLactea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViaLacteaExists(int id)
        {
            return db.ViaLacteas.Count(e => e.id == id) > 0;
        }
    }
}