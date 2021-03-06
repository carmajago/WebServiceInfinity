﻿using System;
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
    public class NebulosasController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/Nebulosas
        public IQueryable<Nebulosa> GetNebulosas()
        {
            return db.Nebulosas.Include(xx => xx.sistemasPlanetarios);
        }

        // GET: api/Nebulosas/5
        [ResponseType(typeof(Nebulosa))]
        public IHttpActionResult GetNebulosa(int id)
        {
            Nebulosa nebulosa = db.Nebulosas.Include(xx=>xx.sistemasPlanetarios).Include(yy=>yy.grafo).FirstOrDefault(xx=>xx.id==id);
            if (nebulosa == null)
            {
                return NotFound();
            }

            return Ok(nebulosa);
        }

        // PUT: api/Nebulosas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNebulosa(Nebulosa nebulosa)
        {
            nebulosa.grafo = null;
            nebulosa.sistemasPlanetarios = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            db.Entry(nebulosa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NebulosaExists(nebulosa.id))
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

        // POST: api/Nebulosas
        [ResponseType(typeof(Nebulosa))]
        public IHttpActionResult PostNebulosa(Nebulosa nebulosa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nebulosas.Add(nebulosa);
            db.SaveChanges();
          
            return CreatedAtRoute("DefaultApi", new { id = nebulosa.id }, nebulosa);
        }

        // DELETE: api/Nebulosas/5
        [ResponseType(typeof(Nebulosa))]
        public IHttpActionResult DeleteNebulosa(int id)
        {
            Nebulosa nebulosa = db.Nebulosas.Find(id);
            if (nebulosa == null)
            {
                return NotFound();
            }
            List<AristaSistema> aristas = db.AristaSistemas.Where(xx => xx.origenFK == id || xx.destinoFK == id).ToList();

            if (aristas != null)
                db.AristaSistemas.RemoveRange(aristas);

            db.Nebulosas.Remove(nebulosa);
            db.SaveChanges();

            return Ok(nebulosa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NebulosaExists(int id)
        {
            return db.Nebulosas.Count(e => e.id == id) > 0;
        }
    }
}