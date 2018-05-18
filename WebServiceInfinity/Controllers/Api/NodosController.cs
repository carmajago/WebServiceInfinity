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
    public class NodosController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/Nodos
        public IQueryable<Nodo> GetNodos()
        {
            return db.Nodos;
        }

        // GET: api/Nodos/5
        [ResponseType(typeof(Nodo))]
        public IHttpActionResult GetNodo(int id)
        {
            Nodo nodo = db.Nodos.Find(id);
            if (nodo == null)
            {
                return NotFound();
            }

            return Ok(nodo);
        }

        // PUT: api/Nodos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNodo(int id, Nodo nodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nodo.id)
            {
                return BadRequest();
            }

            db.Entry(nodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodoExists(id))
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

        // POST: api/Nodos
        [ResponseType(typeof(Nodo))]
        public IHttpActionResult PostNodo(Nodo nodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nodos.Add(nodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nodo.id }, nodo);
        }

        // DELETE: api/Nodos/5
        [ResponseType(typeof(Nodo))]
        public IHttpActionResult DeleteNodo(int id)
        {
            Nodo nodo = db.Nodos.Find(id);
            if (nodo == null)
            {
                return NotFound();
            }

            db.Nodos.Remove(nodo);
            db.SaveChanges();

            return Ok(nodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NodoExists(int id)
        {
            return db.Nodos.Count(e => e.id == id) > 0;
        }
    }
}