using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using StaffingPlanner.Models;


namespace StaffingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private ClientOpportunitiesEntities db = new ClientOpportunitiesEntities();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Projects
        public ActionResult Report()
        {
            var projects = db.Projects.Include(p => p.Client);
            return View(projects.ToList());
        }
    }
}