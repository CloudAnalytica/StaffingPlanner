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
    public class ProjectStatusController : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        // GET: ProjectStatus
        public ActionResult Index()
        {
            return View(db.ProjectStatus1.ToList());
        }

        // GET: ProjectStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatus projectStatus = db.ProjectStatus1.Find(id);
            if (projectStatus == null)
            {
                return HttpNotFound();
            }
            return View(projectStatus);
        }

        // GET: ProjectStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "projectStatusID,projectStatusName")] ProjectStatus projectStatus)
        {
            if (ModelState.IsValid)
            {
                db.ProjectStatus1.Add(projectStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectStatus);
        }

        // GET: ProjectStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatus projectStatus = db.ProjectStatus1.Find(id);
            if (projectStatus == null)
            {
                return HttpNotFound();
            }
            return View(projectStatus);
        }

        // POST: ProjectStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "projectStatusID,projectStatusName")] ProjectStatus projectStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectStatus);
        }

        // GET: ProjectStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatus projectStatus = db.ProjectStatus1.Find(id);
            if (projectStatus == null)
            {
                return HttpNotFound();
            }
            return View(projectStatus);
        }

        // POST: ProjectStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectStatus projectStatus = db.ProjectStatus1.Find(id);
            db.ProjectStatus1.Remove(projectStatus);
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
