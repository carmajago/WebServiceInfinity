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
    public class DepositosController : ApiController
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: api/Depositos
        public IQueryable<Deposito> GetNodoes()
        {
            return db.Depositos;
        }

        // GET: api/Depositos/5
        [ResponseType(typeof(Deposito))]
        public IHttpActionResult GetDeposito(int id)
        {
            Deposito deposito = db.Depositos.FirstOrDefault(xx => xx.sistemaPlanetarioFK == id);
            

            return Ok(deposito);
        }

        // PUT: api/Depositos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeposito(int id, Deposito deposito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deposito.id)
            {
                return BadRequest();
            }

            db.Entry(deposito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(id))
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

        // POST: api/Depositos
        [ResponseType(typeof(Deposito))]
        public IHttpActionResult PostDeposito(Deposito deposito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Depositos.Add(deposito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deposito.id }, deposito);
        }

        // DELETE: api/Depositos/5
        [ResponseType(typeof(Deposito))]
        public IHttpActionResult DeleteDeposito(int id)
        {
            Deposito deposito = db.Depositos.Find(id);
            if (deposito == null)
            {
                return NotFound();
            }

            db.Depositos.Remove(deposito);
            db.SaveChanges();

            return Ok(deposito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepositoExists(int id)
        {
            return db.Depositos.Count(e => e.id == id) > 0;
        }
    }
}