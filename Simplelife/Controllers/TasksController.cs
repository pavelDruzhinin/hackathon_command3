using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;
using Simplelife.Models;

namespace Simplelife.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {

                return View(db.Objectives.ToList());
            }
        }

        [HttpGet]
        public ActionResult Tasks(string date)
        {
            using (var db = new ApplicationDbContext())
            {
                string userId = User.Identity.GetUserId();
                DateTime _date = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                return View("Tasks", db.Objectives.Where(x => EntityFunctions.TruncateTime(x.Date) == EntityFunctions.TruncateTime(_date) && x.ApplicationUser == db.Users.FirstOrDefault(y => y.Id == userId)).ToList());
            }
        }

        [HttpPost]
        public ActionResult save(string taskname, string taskdate, string taskdescr)
        {

            using (var db = new ApplicationDbContext())
            {
                if (taskname.IsEmpty() || taskdate.IsEmpty())
                    return View("Index", db.Objectives.ToList());

                string userId = User.Identity.GetUserId();
                DateTime date = DateTime.ParseExact(taskdate, "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None);
                var task = new Objective()
                {
                    ApplicationUser = db.Users.FirstOrDefault(x => x.Id == userId),
                    Date = date,
                    Description = taskdescr,
                    Name = taskname
                };
                db.Objectives.Add(task);
                db.SaveChanges();

                return View("Index", db.Objectives.ToList());
            }
        }
    }
}