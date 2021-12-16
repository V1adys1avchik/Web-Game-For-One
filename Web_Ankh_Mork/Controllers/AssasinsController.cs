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
    public class AssasinsController : Controller
    {
        private AnkhMorokContext db = new AnkhMorokContext();

        // GET: Assasins
        public ActionResult Index()
        {
            return View(db.Assasins.ToList());
        }

        // GET: Assasins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assasin assasin = db.Assasins.Find(id);
            if (assasin == null)
            {
                return HttpNotFound();
            }
            return View(assasin);
        }

        // GET: Assasins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assasins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,HighestReward,LowestReward,IsOcupied")] Assasin assasin)
        {
            if (ModelState.IsValid)
            {
                db.Assasins.Add(assasin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assasin);
        }

        // GET: Assasins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assasin assasin = db.Assasins.Find(id);
            if (assasin == null)
            {
                return HttpNotFound();
            }
            return View(assasin);
        }

        // POST: Assasins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,HighestReward,LowestReward,IsOcupied")] Assasin assasin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assasin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assasin);
        }

        // GET: Assasins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assasin assasin = db.Assasins.Find(id);
            if (assasin == null)
            {
                return HttpNotFound();
            }
            return View(assasin);
        }

        // POST: Assasins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assasin assasin = db.Assasins.Find(id);
            db.Assasins.Remove(assasin);
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
