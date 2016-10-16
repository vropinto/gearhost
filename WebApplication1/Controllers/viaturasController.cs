using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class viaturasController : Controller
    {
        private vropintoEntities1 db = new vropintoEntities1();

        // GET: viaturas
        public ActionResult Index()
        {
            return View(db.viatura.ToList());
        }

        // GET: viaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viatura viatura = db.viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // GET: viaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: viaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "viatura_id,matricula,movel,marca,modelo,capacidade,peso_bruto,Tara,Oficina")] viatura viatura)
        {
            if (ModelState.IsValid)
            {
                db.viatura.Add(viatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viatura);
        }

        // GET: viaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viatura viatura = db.viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // POST: viaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "viatura_id,matricula,movel,marca,modelo,capacidade,peso_bruto,Tara,Oficina")] viatura viatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viatura);
        }

        // GET: viaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viatura viatura = db.viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // POST: viaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            viatura viatura = db.viatura.Find(id);
            db.viatura.Remove(viatura);
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
