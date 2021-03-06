﻿using System;
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
    public class ConsultantsController : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        // GET: Consultants
        public ActionResult Index()
        {
            return View(db.Consultants.ToList());
        }

        // GET: Consultants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = db.Consultants.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // GET: Consultants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consultantId,consultantName,sogetiStartDate,activeEmployee,lastEditedBy,editDate")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Consultants.Add(consultant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consultant);
        }

        // GET: Consultants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = db.Consultants.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consultantId,consultantName,sogetiStartDate,activeEmployee,lastEditedBy,editDate")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

		// GET: Consultants/Delete/5
		public ActionResult MakeInactive(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Consultant consultant = db.Consultants.Find(id);
			if (consultant == null)
			{
				return HttpNotFound();
			}
			return View(consultant);
		}

		// POST: Consultants/Delete/5
		[HttpPost, ActionName("MakeInactive")]
		[ValidateAntiForgeryToken]
		public ActionResult MakeInactiveConfirmed(int id)
		{
			Consultant consultant = db.Consultants.Find(id);
			consultant.activeEmployee = false;
			db.Entry(consultant).State = EntityState.Modified; ;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: Consultants/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = db.Consultants.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultant consultant = db.Consultants.Find(id);
            db.Consultants.Remove(consultant);
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
