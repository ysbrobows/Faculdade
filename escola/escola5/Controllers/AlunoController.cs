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
    public class AlunoController : Controller
    {
        private modelo db = new modelo();

        // GET: Aluno
        public ActionResult Index()
        {
            var tbl_Aluno = db.tbl_Aluno.Include(t => t.tbl_Disciplina);
            return View(tbl_Aluno.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Aluno tbl_Aluno = db.tbl_Aluno.Find(id);
            if (tbl_Aluno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.ID_Curso = new SelectList(db.tbl_Disciplina, "ID", "Disciplina");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Matricula,ID_Curso")] tbl_Aluno tbl_Aluno)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Aluno.Add(tbl_Aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Curso = new SelectList(db.tbl_Disciplina, "ID", "Disciplina", tbl_Aluno.ID_Curso);
            return View(tbl_Aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Aluno tbl_Aluno = db.tbl_Aluno.Find(id);
            if (tbl_Aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Curso = new SelectList(db.tbl_Disciplina, "ID", "Disciplina", tbl_Aluno.ID_Curso);
            return View(tbl_Aluno);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Matricula,ID_Curso")] tbl_Aluno tbl_Aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Curso = new SelectList(db.tbl_Disciplina, "ID", "Disciplina", tbl_Aluno.ID_Curso);
            return View(tbl_Aluno);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Aluno tbl_Aluno = db.tbl_Aluno.Find(id);
            if (tbl_Aluno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Aluno tbl_Aluno = db.tbl_Aluno.Find(id);
            db.tbl_Aluno.Remove(tbl_Aluno);
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
