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
    public class DepositosController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: Depositos
        public ActionResult Index()
        {
            var depositoes = db.Depositoes.Include(d => d.sistemaPlanetario);
            return View(depositoes.ToList());
        }

        // GET: Depositos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposito deposito = db.Depositoes.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        // GET: Depositos/Create
        public ActionResult Create()
        {
            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre");
            return View();
        }

        // POST: Depositos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sistemaFK,nombre,x,y,z")] Deposito deposito)
        {
            if (ModelState.IsValid)
            {
                db.Depositoes.Add(deposito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", deposito.sistemaFK);
            return View(deposito);
        }

        // GET: Depositos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposito deposito = db.Depositoes.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", deposito.sistemaFK);
            return View(deposito);
        }

        // POST: Depositos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sistemaFK,nombre,x,y,z")] Deposito deposito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deposito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sistemaFK = new SelectList(db.SistemaPlanetarios, "id", "nombre", deposito.sistemaFK);
            return View(deposito);
        }

        // GET: Depositos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposito deposito = db.Depositoes.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        // POST: Depositos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deposito deposito = db.Depositoes.Find(id);
            db.Depositoes.Remove(deposito);
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
