using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simplelife.Models;
using Simplelife.ViewModels;

namespace Simplelife.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                //return View(new NotesViewModel { Categories = db.Categories.ToList(), Notes = db.Notes.ToList() });
                return View();
            }
        }
    }
}