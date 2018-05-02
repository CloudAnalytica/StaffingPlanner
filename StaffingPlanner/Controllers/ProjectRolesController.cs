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
    public class ProjectRolesController : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        // GET: ProjectRoles
        public ActionResult Index()
        {
            var projectRoles = db.ProjectRoles.Include(p => p.Consultant).Include(p => p.Project);
            return View(projectRoles.ToList());
        }

        // GET: ProjectRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectRole projectRole = db.ProjectRoles.Find(id);
            if (projectRole == null)
            {
                return HttpNotFound();
            }
            return View(projectRole);
        }

        // GET: ProjectRoles/Create
        public ActionResult Create()
        {
            ViewBag.consultantId = new SelectList(db.Consultants, "consultantId", "consultantName");
            ViewBag.projectRoleId = new SelectList(db.Projects, "projectId", "location");
            return View();
        }

        // POST: ProjectRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "projectRoleId,projectId,consultantId,projectRoleName,maxTargetGrade,targetedNewHireGrade,candidateConfirmed,expectedStartDate,actualStartDate,endDate,lastEditedBy,editDate")] ProjectRole projectRole)
        {
            if (ModelState.IsValid)
            {
                db.ProjectRoles.Add(projectRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consultantId = new SelectList(db.Consultants, "consultantId", "consultantName", projectRole.consultantId);
            ViewBag.projectRoleId = new SelectList(db.Projects, "projectId", "location", projectRole.projectRoleId);
            return View(projectRole);
        }

        // GET: ProjectRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectRole projectRole = db.ProjectRoles.Find(id);
            if (projectRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.consultantId = new SelectList(db.Consultants, "consultantId", "consultantName", projectRole.consultantId);
            ViewBag.projectRoleId = new SelectList(db.Projects, "projectId", "location", projectRole.projectRoleId);
            return View(projectRole);
        }

        // POST: ProjectRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "projectRoleId,projectId,consultantId,projectRoleName,maxTargetGrade,targetedNewHireGrade,candidateConfirmed,expectedStartDate,actualStartDate,endDate,lastEditedBy,editDate")] ProjectRole projectRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consultantId = new SelectList(db.Consultants, "consultantId", "consultantName", projectRole.consultantId);
            ViewBag.projectRoleId = new SelectList(db.Projects, "projectId", "location", projectRole.projectRoleId);
            return View(projectRole);
        }

        // GET: ProjectRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectRole projectRole = db.ProjectRoles.Find(id);
            if (projectRole == null)
            {
                return HttpNotFound();
            }
            return View(projectRole);
        }

        // POST: ProjectRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectRole projectRole = db.ProjectRoles.Find(id);
            db.ProjectRoles.Remove(projectRole);
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
