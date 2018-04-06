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
    public class TeletransportadoresController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/Teletransportadores
        public IQueryable<Teletransportador> GetTeletransportadors()
        {
            return db.Teletransportadors;
        }

        // GET: api/Teletransportadores/5
        [ResponseType(typeof(Teletransportador))]
        public IHttpActionResult GetTeletransportador(int id)
        {
            Teletransportador teletransportador = db.Teletransportadors.Find(id);
            if (teletransportador == null)
            {
                return NotFound();
            }

            return Ok(teletransportador);
        }

        // PUT: api/Teletransportadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeletransportador(int id, Teletransportador teletransportador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teletransportador.sistemaFK)
            {
                return BadRequest();
            }

            db.Entry(teletransportador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeletransportadorExists(id))
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

        // POST: api/Teletransportadores
        [ResponseType(typeof(Teletransportador))]
        public IHttpActionResult PostTeletransportador(Teletransportador teletransportador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teletransportadors.Add(teletransportador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TeletransportadorExists(teletransportador.sistemaFK))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = teletransportador.sistemaFK }, teletransportador);
        }

        // DELETE: api/Teletransportadores/5
        [ResponseType(typeof(Teletransportador))]
        public IHttpActionResult DeleteTeletransportador(int id)
        {
            Teletransportador teletransportador = db.Teletransportadors.Find(id);
            if (teletransportador == null)
            {
                return NotFound();
            }

            db.Teletransportadors.Remove(teletransportador);
            db.SaveChanges();

            return Ok(teletransportador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeletransportadorExists(int id)
        {
            return db.Teletransportadors.Count(e => e.sistemaFK == id) > 0;
        }
    }
}