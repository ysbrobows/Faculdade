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
    public class CursoController : Controller
    {
        private modelo db = new modelo();

        // GET: Curso
        public ActionResult Index()
        {
            return View(db.tbl_Curso.ToList());
        }

        public JsonResult Listar()
        {
            var retorno = (from x in db.tbl_Curso.ToList()
                           select new ViewModels.CursoVM
                           {
                               ID = x.ID.ToString(),
                               Curso = x.Curso
                           }).ToList();
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Deletar(int id)
        {
            try
            {
                tbl_Curso curso = db.tbl_Curso.Find(id);

                if (curso != null)
                {
                    db.tbl_Curso.Remove(curso);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Salvar(tbl_Curso curso)
        {
            if (db.tbl_Curso.Any(x => x.Curso == curso.Curso))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }


            db.tbl_Curso.Add(curso);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Editar(tbl_Curso curso)
        {
            db.Entry(curso).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
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
