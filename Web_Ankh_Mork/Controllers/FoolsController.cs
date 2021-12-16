using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Ankh_Mork.DB;
using Web_Ankh_Mork.DB.Entity;

namespace Web_Ankh_Mork.Controllers
{
    [Authorize]
    public class FoolsController : Controller
    {
        private AnkhMorokContext db = new AnkhMorokContext();

        // GET: Fools
        public ActionResult Index()
        {
            return View(db.Fools.ToList());
        }

        // GET: Fools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fool fool = db.Fools.Find(id);
            if (fool == null)
            {
                return HttpNotFound();
            }
            return View(fool);
        }

        // GET: Fools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FoolType,Name,Salary,Replic")] Fool fool)
        {
            if (ModelState.IsValid)
            {
                db.Fools.Add(fool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fool);
        }

        // GET: Fools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fool fool = db.Fools.Find(id);
            if (fool == null)
            {
                return HttpNotFound();
            }
            return View(fool);
        }

        // POST: Fools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FoolType,Name,Salary,Replic")] Fool fool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fool);
        }

        // GET: Fools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fool fool = db.Fools.Find(id);
            if (fool == null)
            {
                return HttpNotFound();
            }
            return View(fool);
        }

        // POST: Fools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fool fool = db.Fools.Find(id);
            db.Fools.Remove(fool);
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
