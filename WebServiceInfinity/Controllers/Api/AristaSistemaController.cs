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
    public class AristaSistemaController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/AristaSistema
        public IQueryable<AristaSistema> GetAristaSistemas()
        {
            return db.AristaSistemas;
        }

        // GET: api/AristaSistema/5
        [ResponseType(typeof(AristaSistema))]
        public IHttpActionResult GetAristaSistema(int id)
        {
            AristaSistema aristaSistema = db.AristaSistemas.Find(id);
            if (aristaSistema == null)
            {
                return NotFound();
            }

            return Ok(aristaSistema);
        }

        // PUT: api/AristaSistema/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAristaSistema(int id, AristaSistema aristaSistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aristaSistema.id)
            {
                return BadRequest();
            }

            db.Entry(aristaSistema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AristaSistemaExists(id))
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

        // POST: api/AristaSistema
        [ResponseType(typeof(AristaSistema))]
        public IHttpActionResult PostAristaSistema(AristaSistema aristaSistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ExisteConexion(aristaSistema.origenFK, aristaSistema.destinoFK))
            {
                return BadRequest("Ya existe conexion");
            }

            db.AristaSistemas.Add(aristaSistema);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aristaSistema.id }, aristaSistema);
        }

        // DELETE: api/AristaSistema/5
        [ResponseType(typeof(AristaSistema))]
        public IHttpActionResult DeleteAristaSistema(int id)
        {
            AristaSistema aristaSistema = db.AristaSistemas.Find(id);
            if (aristaSistema == null)
            {
                return NotFound();
            }

            db.AristaSistemas.Remove(aristaSistema);
            db.SaveChanges();

            return Ok(aristaSistema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AristaSistemaExists(int id)
        {
            return db.AristaSistemas.Count(e => e.id == id) > 0;
        }
        public bool ExisteConexion(int origen, int destino)
        {
            return db.AristaSistemas.Count(xx => (xx.origenFK == origen && xx.destinoFK == destino) || (xx.origenFK == destino && xx.destinoFK == origen)) > 0;
        }
    }
}