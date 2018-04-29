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
    public class SistemaPlanetarioController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/SistemaPlanetario
        public IQueryable<SistemaPlanetario> GetSistemaPlanetarios()
        {
            return db.SistemaPlanetarios;
        }

        // GET: api/SistemaPlanetario/5
        [ResponseType(typeof(SistemaPlanetario))]
        public IHttpActionResult GetSistemaPlanetario(int id)
        {
            SistemaPlanetario sistemaPlanetario = db.SistemaPlanetarios.Find(id);
            if (sistemaPlanetario == null)
            {
                return NotFound();
            }

            return Ok(sistemaPlanetario);
        }

        // PUT: api/SistemaPlanetario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSistemaPlanetario(SistemaPlanetario sistemaPlanetario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          

            db.Entry(sistemaPlanetario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaPlanetarioExists(sistemaPlanetario.id))
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

        // POST: api/SistemaPlanetario
        [ResponseType(typeof(SistemaPlanetario))]
        public IHttpActionResult PostSistemaPlanetario(SistemaPlanetario sistemaPlanetario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SistemaPlanetarios.Add(sistemaPlanetario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sistemaPlanetario.id }, sistemaPlanetario);
        }

        // DELETE: api/SistemaPlanetario/5
        [ResponseType(typeof(SistemaPlanetario))]
        public IHttpActionResult DeleteSistemaPlanetario(int id)
        {
            SistemaPlanetario sistemaPlanetario = db.SistemaPlanetarios.Find(id);
            if (sistemaPlanetario == null)
            {
                return NotFound();
            }

            db.SistemaPlanetarios.Remove(sistemaPlanetario);
            db.SaveChanges();

            return Ok(sistemaPlanetario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SistemaPlanetarioExists(int id)
        {
            return db.SistemaPlanetarios.Count(e => e.id == id) > 0;
        }
    }
}