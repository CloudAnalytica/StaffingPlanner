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
    public class Index : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        // GET: Projects
        public ActionResult IndexGet()
        {
            var projects = db.Projects.Include(p => p.Client).Include(p => p.ProjectStatus).Include(p => p.ProjectRole);
            return View(projects.ToList());
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
