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
    public class PlanetasController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: Planetas
        public ActionResult Index()
        {
            var planetas = db.Planetas.Include(p => p.sistemaPlanetario);
            return View(planetas.ToList());
        }

        // GET: Planetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planeta planeta = db.Planetas.Find(id);
            if (planeta == null)
            {
                return HttpNotFound();
            }
            return View(planeta);
        }

        // GET: Planetas/Create
        public ActionResult Create()
        {
            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre");
            return View();
        }

        // POST: Planetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idModelo,x,y,z,iridio,platino,paladio,elementoZero,sistemaPlanetarioFK")] Planeta planeta)
        {
            if (ModelState.IsValid)
            {
                db.Planetas.Add(planeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", planeta.sistemaPlanetarioFK);
            return View(planeta);
        }

        // GET: Planetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planeta planeta = db.Planetas.Find(id);
            if (planeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", planeta.sistemaPlanetarioFK);
            return View(planeta);
        }

        // POST: Planetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idModelo,x,y,z,iridio,platino,paladio,elementoZero,sistemaPlanetarioFK")] Planeta planeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", planeta.sistemaPlanetarioFK);
            return View(planeta);
        }

        // GET: Planetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planeta planeta = db.Planetas.Find(id);
            if (planeta == null)
            {
                return HttpNotFound();
            }
            return View(planeta);
        }

        // POST: Planetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planeta planeta = db.Planetas.Find(id);
            db.Planetas.Remove(planeta);
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
