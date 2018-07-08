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
            Planeta planetas = db.Planetas.Find(id);
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
            planeta.deposito = null;
            planeta.teletransportador = null;


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

            List<AristaNodo> aristas = db.AristaNodoes.Where(xx=>xx.origenFK==id || xx.destinoFK==id).ToList();
            db.AristaNodoes.RemoveRange(aristas);
            Planeta planeta = db.Planetas.Find(id);
            Teletransportador teletransportador = db.Teletransportadores.Find(id);
            Deposito deposito = db.Depositos.Find(id);

            if (planeta == null)
            {
                return NotFound();
            }
            if (teletransportador != null)
            {
                db.Teletransportadores.Remove(teletransportador);
            }
            if (deposito != null)
            {
                db.Depositos.Remove(deposito);
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

        
    }
}