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
    public class PlanetasController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/Planetas
        public IQueryable<Planeta> GetNodoes()
        {
            return db.Planetas;
        }

        // GET: api/Planetas/5
        [ResponseType(typeof(Planeta))]
        public IHttpActionResult GetPlaneta(int id)
        {
            List<Planeta> planetas = db.Planetas.Where(xx=>xx.sistemaPlanetarioFK ==id).ToList();
            if (planetas == null)
            {
                return NotFound();
            }

            return Ok(planetas);
        }

        // PUT: api/Planetas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlaneta(int id, Planeta planeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planeta.id)
            {
                return BadRequest();
            }

            db.Entry(planeta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetaExists(id))
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

        // POST: api/Planetas
        [ResponseType(typeof(Planeta))]
        public IHttpActionResult PostPlaneta(Planeta planeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Planetas.Add(planeta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = planeta.id }, planeta);
        }

        // DELETE: api/Planetas/5
        [ResponseType(typeof(Planeta))]
        public IHttpActionResult DeletePlaneta(int id)
        {
            Planeta planeta = db.Planetas.Find(id);
            if (planeta == null)
            {
                return NotFound();
            }

            db.Planetas.Remove(planeta);
            db.SaveChanges();

            return Ok(planeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanetaExists(int id)
        {
            return db.Teletransportadores.Count(e => e.id == id) > 0;
        }
    }
}