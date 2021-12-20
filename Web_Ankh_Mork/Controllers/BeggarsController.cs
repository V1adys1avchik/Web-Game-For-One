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
    public class BeggarsController : Controller
    {
        private AnkhMorokContext db = new AnkhMorokContext();

        // GET: Beggars
        public ActionResult Index()
        {
            return View(db.Beggars.ToList());
        }

        // GET: Beggars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beggar beggar = db.Beggars.Find(id);
            if (beggar == null)
            {
                return HttpNotFound();
            }
            return View(beggar);
        }

        // GET: Beggars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beggars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BeggarType,Name,AmountOfMoney,Replic")] Beggar beggar)
        {
            if (ModelState.IsValid)
            {
                db.Beggars.Add(beggar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beggar);
        }

        // GET: Beggars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beggar beggar = db.Beggars.Find(id);
            if (beggar == null)
            {
                return HttpNotFound();
            }
            return View(beggar);
        }

        // POST: Beggars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BeggarType,Name,AmountOfMoney,Replic")] Beggar beggar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beggar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beggar);
        }

        // GET: Beggars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beggar beggar = db.Beggars.Find(id);
            if (beggar == null)
            {
                return HttpNotFound();
            }
            return View(beggar);
        }

        // POST: Beggars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beggar beggar = db.Beggars.Find(id);
            db.Beggars.Remove(beggar);
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
