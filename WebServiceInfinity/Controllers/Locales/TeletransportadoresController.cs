using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServiceInfinity.Models;

namespace WebServiceInfinity.Controllers.Locales
{
    public class TeletransportadoresController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: Teletransportadores
        public ActionResult Index()
        {
            var teletransportadors = db.Teletransportadors.Include(t => t.sistemaPlanetario);
            return View(teletransportadors.ToList());
        }

        // GET: Teletransportadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teletransportador teletransportador = db.Teletransportadors.Find(id);
            if (teletransportador == null)
            {
                return HttpNotFound();
            }
            return View(teletransportador);
        }

        // GET: Teletransportadores/Create
        public ActionResult Create()
        {
            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre");
            return View();
        }

        // POST: Teletransportadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sistemaFK,nombre,x,y,z")] Teletransportador teletransportador)
        {
            if (ModelState.IsValid)
            {
                db.Teletransportadors.Add(teletransportador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", teletransportador.sistemaFK);
            return View(teletransportador);
        }

        // GET: Teletransportadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teletransportador teletransportador = db.Teletransportadors.Find(id);
            if (teletransportador == null)
            {
                return HttpNotFound();
            }
            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", teletransportador.sistemaFK);
            return View(teletransportador);
        }

        // POST: Teletransportadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sistemaFK,nombre,x,y,z")] Teletransportador teletransportador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teletransportador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", teletransportador.sistemaFK);
            return View(teletransportador);
        }

        // GET: Teletransportadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teletransportador teletransportador = db.Teletransportadors.Find(id);
            if (teletransportador == null)
            {
                return HttpNotFound();
            }
            return View(teletransportador);
        }

        // POST: Teletransportadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teletransportador teletransportador = db.Teletransportadors.Find(id);
            db.Teletransportadors.Remove(teletransportador);
            db.SaveChanges();
            return RedirectToAction("Index");
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
