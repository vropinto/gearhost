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
    public class inspecaosController : Controller
    {
        private vropintoEntities1 db = new vropintoEntities1();

        // GET: inspecaos
        public ActionResult Index()
        {
            var inspecao = db.inspecao.Include(i => i.viatura);
            return View(inspecao.ToList());
        }

        // GET: inspecaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inspecao inspecao = db.inspecao.Find(id);
            if (inspecao == null)
            {
                return HttpNotFound();
            }
            return View(inspecao);
        }

        // GET: inspecaos/Create
        public ActionResult Create()
        {
            ViewBag.viatura_id = new SelectList(db.viatura, "viatura_id", "matricula");
            return View();
        }

        // POST: inspecaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inspecao_id,viatura_id,motorista_id,data,chassis,Eixo_Frente,Eixo_Traz,Motor,Caixa_Velocidades,Sistema_de_Ar,Sistema_Eletrico,Outros")] inspecao inspecao)
        {
            if (ModelState.IsValid)
            {
                db.inspecao.Add(inspecao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.viatura_id = new SelectList(db.viatura, "viatura_id", "matricula", inspecao.viatura_id);
            return View(inspecao);
        }

        // GET: inspecaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inspecao inspecao = db.inspecao.Find(id);
            if (inspecao == null)
            {
                return HttpNotFound();
            }
            ViewBag.viatura_id = new SelectList(db.viatura, "viatura_id", "matricula", inspecao.viatura_id);
            return View(inspecao);
        }

        // POST: inspecaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inspecao_id,viatura_id,motorista_id,data,chassis,Eixo_Frente,Eixo_Traz,Motor,Caixa_Velocidades,Sistema_de_Ar,Sistema_Eletrico,Outros")] inspecao inspecao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspecao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.viatura_id = new SelectList(db.viatura, "viatura_id", "matricula", inspecao.viatura_id);
            return View(inspecao);
        }

        // GET: inspecaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inspecao inspecao = db.inspecao.Find(id);
            if (inspecao == null)
            {
                return HttpNotFound();
            }
            return View(inspecao);
        }

        // POST: inspecaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inspecao inspecao = db.inspecao.Find(id);
            db.inspecao.Remove(inspecao);
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
