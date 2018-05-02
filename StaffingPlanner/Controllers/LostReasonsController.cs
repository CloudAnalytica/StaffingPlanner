using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffingPlanner.Models;

namespace StaffingPlanner.Controllers
{
    public class LostReasonsController : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        // GET: LostReasons
        public ActionResult Index()
        {
            return View(db.LostReasons.ToList());
        }

        // GET: LostReasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostReason lostReason = db.LostReasons.Find(id);
            if (lostReason == null)
            {
                return HttpNotFound();
            }
            return View(lostReason);
        }

        // GET: LostReasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LostReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lostReasonId,reason")] LostReason lostReason)
        {
            if (ModelState.IsValid)
            {
                db.LostReasons.Add(lostReason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lostReason);
        }

        // GET: LostReasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostReason lostReason = db.LostReasons.Find(id);
            if (lostReason == null)
            {
                return HttpNotFound();
            }
            return View(lostReason);
        }

        // POST: LostReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lostReasonId,reason")] LostReason lostReason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lostReason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lostReason);
        }

        // GET: LostReasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostReason lostReason = db.LostReasons.Find(id);
            if (lostReason == null)
            {
                return HttpNotFound();
            }
            return View(lostReason);
        }

        // POST: LostReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LostReason lostReason = db.LostReasons.Find(id);
            db.LostReasons.Remove(lostReason);
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
