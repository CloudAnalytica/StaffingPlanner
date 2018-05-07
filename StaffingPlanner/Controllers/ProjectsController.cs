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
    public class ProjectsController : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Client).Include(p => p.ProjectStatus);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {

			ViewBag.clientId = new SelectList(db.Clients, "clientId", "clientName" );
            ViewBag.projectStatusID = new SelectList(db.ProjectStatus1, "projectStatusID", "projectStatusName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "projectId,clientId,projectStatusID,location,sponsor,requestDate,projectName,projectActive,comment,lastEditedBy,editDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientId = new SelectList(db.Clients, "clientId", "clientName", project.clientId);
            ViewBag.projectStatusID = new SelectList(db.ProjectStatus1, "projectStatusID", "projectStatusName", project.projectStatusID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientId = new SelectList(db.Clients, "clientId", "clientName", project.clientId);
            ViewBag.projectStatusID = new SelectList(db.ProjectStatus1, "projectStatusID", "projectStatusName", project.projectStatusID);
            ViewBag.projectId = new SelectList(db.ProjectRoles, "projectRoleId", "projectRoleName", project.projectId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "projectId,clientId,projectStatusID,location,sponsor,requestDate,projectName,projectActive,comment,lastEditedBy,editDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientId = new SelectList(db.Clients, "clientId", "clientName", project.clientId);
            ViewBag.projectStatusID = new SelectList(db.ProjectStatus1, "projectStatusID", "projectStatusName", project.projectStatusID);
            ViewBag.projectId = new SelectList(db.ProjectRoles, "projectRoleId", "projectRoleName", project.projectId);
            return View(project);
        }

		// GET: Projects/MakeInactive/5
		public ActionResult MakeInactive(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Project project = db.Projects.Find(id);
			if (project == null)
			{
				return HttpNotFound();
			}
			return View(project);
		}

		// POST: Projects/MakeInactive/5
		[HttpPost, ActionName("MakeInactive")]
		[ValidateAntiForgeryToken]
		public ActionResult MakeInactiveConfirmed(int id)
		{
			Project project = db.Projects.Find(id);
			project.projectActive = false;
			db.Entry(project).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: Projects/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
