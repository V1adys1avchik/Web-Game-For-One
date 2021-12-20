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
    public class ThiefsController : Controller
    {
        private AnkhMorokContext db = new AnkhMorokContext();

        // GET: Thiefs
        public ActionResult Index()
        {
            return View(db.Thiefs.ToList());
        }

        // GET: Thiefs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thief thief = db.Thiefs.Find(id);
            if (thief == null)
            {
                return HttpNotFound();
            }
            return View(thief);
        }

        // GET: Thiefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thiefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Fee")] Thief thief)
        {
            if (ModelState.IsValid)
            {
                db.Thiefs.Add(thief);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thief);
        }

        // GET: Thiefs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thief thief = db.Thiefs.Find(id);
            if (thief == null)
            {
                return HttpNotFound();
            }
            return View(thief);
        }

        // POST: Thiefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Thief thief)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thief).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thief);
        }

        // GET: Thiefs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thief thief = db.Thiefs.Find(id);
            if (thief == null)
            {
                return HttpNotFound();
            }
            return View(thief);
        }

        // POST: Thiefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thief thief = db.Thiefs.Find(id);
            db.Thiefs.Remove(thief);
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
