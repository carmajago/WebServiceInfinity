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
    public class NodoesController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: Nodoes
        public ActionResult Index()
        {
            var nodos = db.Nodos.Include(n => n.sistemaPlanetario);
            return View(nodos.ToList());
        }

        // GET: Nodoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nodo nodo = db.Nodos.Find(id);
            if (nodo == null)
            {
                return HttpNotFound();
            }
            return View(nodo);
        }

        // GET: Nodoes/Create
        public ActionResult Create()
        {
            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre");
            return View();
        }

        // POST: Nodoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,x,y,z,idModelo,sistemaPlanetarioFK")] Nodo nodo)
        {
            if (ModelState.IsValid)
            {
                db.Nodos.Add(nodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", nodo.sistemaPlanetarioFK);
            return View(nodo);
        }

        // GET: Nodoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nodo nodo = db.Nodos.Find(id);
            if (nodo == null)
            {
                return HttpNotFound();
            }
            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", nodo.sistemaPlanetarioFK);
            return View(nodo);
        }

        // POST: Nodoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,x,y,z,idModelo,sistemaPlanetarioFK")] Nodo nodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sistemaPlanetarioFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", nodo.sistemaPlanetarioFK);
            return View(nodo);
        }

        // GET: Nodoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nodo nodo = db.Nodos.Find(id);
            if (nodo == null)
            {
                return HttpNotFound();
            }
            return View(nodo);
        }

        // POST: Nodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nodo nodo = db.Nodos.Find(id);
            db.Nodos.Remove(nodo);
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
