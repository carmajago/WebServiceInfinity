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
    public class AristaNodoController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/AristaNodo
        public IQueryable<AristaNodo> GetAristaNodoes()
        {
            return db.AristaNodoes;
        }

        // GET: api/AristaNodo/5
        [ResponseType(typeof(AristaNodo))]
        public IHttpActionResult GetAristaNodo(int id)
        {
            AristaNodo aristaNodo = db.AristaNodoes.Find(id);
            if (aristaNodo == null)
            {
                return NotFound();
            }

            return Ok(aristaNodo);
        }

        // PUT: api/AristaNodo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAristaNodo(int id, AristaNodo aristaNodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aristaNodo.id)
            {
                return BadRequest();
            }

            db.Entry(aristaNodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AristaNodoExists(id))
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

        // POST: api/AristaNodo
        [ResponseType(typeof(AristaNodo))]
        public IHttpActionResult PostAristaNodo(AristaNodo aristaNodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(ExisteConexion(aristaNodo.origenFK,aristaNodo.destinoFK))
            {
                return BadRequest("Ya existe conexion");
            }

            db.AristaNodoes.Add(aristaNodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aristaNodo.id }, aristaNodo);
        }

        // DELETE: api/AristaNodo/5
        [ResponseType(typeof(AristaNodo))]
        public IHttpActionResult DeleteAristaNodo(int id)
        {
            AristaNodo aristaNodo = db.AristaNodoes.Find(id);
            if (aristaNodo == null)
            {
                return NotFound();
            }

            db.AristaNodoes.Remove(aristaNodo);
            db.SaveChanges();

            return Ok(aristaNodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AristaNodoExists(int id)
        {
            return db.AristaNodoes.Count(e => e.id == id) > 0;
        }
        public bool ExisteConexion(int origen, int destino)
        {
            return db.AristaNodoes.Count(xx=>( xx.origenFK == origen && xx.destinoFK == destino) || (xx.origenFK == destino && xx.destinoFK == origen))>0;
        }

    }
}