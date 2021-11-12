using ControleGastos.Context;
using ControleGastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleGastos.Controllers
{
    public class GastoController : Controller
    {
        public ActionResult Index()
        {
            SqlContext db = new SqlContext();

            var gastos = db.Gastos
                            .Include("Categoria")
                            .ToList();

            return View(gastos);
        }

        public ActionResult Create()
        {
            FillCategory(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gasto obj)
        {
            SqlContext db = new SqlContext();
            if (ModelState.IsValid)
            {
                db.Gastos.Add(obj);
                db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public ActionResult Details(int id)
        {
            SqlContext db = new SqlContext();
            var gasto = db.Gastos.Find(id);

            return View(gasto);
        }

        public ActionResult Edit(int id)
        {
            SqlContext db = new SqlContext();
            var gasto = db.Gastos.Find(id);

            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gasto obj)
        {
            SqlContext db = new SqlContext();
            if (ModelState.IsValid)
            {

                using (var dbContext = new SqlContext())
                {
                    Gasto gasto = db.Gastos.First(g => g.Id == obj.Id);
                    gasto.Nome = obj.Nome;
                    dbContext.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }

        public ActionResult Delete(int id)
        {
            SqlContext db = new SqlContext();
            var gasto = db.Gastos.Find(id);

            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Gasto obj)
        {
            SqlContext db = new SqlContext();
            if (ModelState.IsValid)
            {
                Gasto gasto = db.Gastos.Find(obj.Id);
                db.Gastos.Remove(gasto);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }

        public void FillCategory(int id)
        {
            SqlContext db = new SqlContext();

            ViewBag.CategoryId = new SelectList(db.Categorias.ToList(), "Id", "Name", id);

        }


    }
}
