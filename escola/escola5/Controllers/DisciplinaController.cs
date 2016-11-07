using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using escola5.Models;

namespace escola5.Controllers
{
    public class DisciplinaController : Controller
    {
        private modelo db = new modelo();

        // GET: Disciplina
        public ActionResult Index()
        {
            var tbl_Disciplina = db.tbl_Disciplina.Include(t => t.tbl_Curso);
            return View(tbl_Disciplina.ToList());
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Disciplina tbl_Disciplina = db.tbl_Disciplina.Find(id);
            if (tbl_Disciplina == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Disciplina);
        }

        // GET: Disciplina/Create
        public ActionResult Create()
        {
            ViewBag.ID_Curso = new SelectList(db.tbl_Curso, "ID", "Curso");
            return View();
        }

        // POST: Disciplina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Disciplina,ID_Curso")] tbl_Disciplina tbl_Disciplina)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Disciplina.Add(tbl_Disciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Curso = new SelectList(db.tbl_Curso, "ID", "Curso", tbl_Disciplina.ID_Curso);
            return View(tbl_Disciplina);
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Disciplina tbl_Disciplina = db.tbl_Disciplina.Find(id);
            if (tbl_Disciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Curso = new SelectList(db.tbl_Curso, "ID", "Curso", tbl_Disciplina.ID_Curso);
            return View(tbl_Disciplina);
        }

        // POST: Disciplina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Disciplina,ID_Curso")] tbl_Disciplina tbl_Disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Disciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Curso = new SelectList(db.tbl_Curso, "ID", "Curso", tbl_Disciplina.ID_Curso);
            return View(tbl_Disciplina);
        }

        // GET: Disciplina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Disciplina tbl_Disciplina = db.tbl_Disciplina.Find(id);
            if (tbl_Disciplina == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Disciplina tbl_Disciplina = db.tbl_Disciplina.Find(id);
            db.tbl_Disciplina.Remove(tbl_Disciplina);
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
