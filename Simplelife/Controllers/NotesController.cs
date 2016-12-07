using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Simplelife.Models;
using Simplelife.ViewModels;

namespace Simplelife.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index(int? categoryId)
        {
            using (var db = new ApplicationDbContext())
            {
                return View(new NotesViewModel { Categories = db.Categories.ToList(),
                    Notes = db.Notes.OrderByDescending(x => x.CreateData).ToList(),
                    CurrentCategory = db.Categories.FirstOrDefault(x => x.Id == (categoryId ?? db.Categories.FirstOrDefault(c => c.Name == "Входящие").Id))
                });
            }
        }

        [HttpPost]
        public ActionResult saveNote(int? noteId, int categoryId, string content)
        {
            using (var db = new ApplicationDbContext())
            {
                if (noteId == null)
                {
                    string userId = User.Identity.GetUserId();
                    Note note = new Note
                    {
                        Category = db.Categories.FirstOrDefault(x => x.Id == categoryId),
                        Content = content,
                        CreateData = DateTime.Now,
                        ApplicationUser = db.Users.FirstOrDefault(x => x.Id == userId)
                    };
                    db.Notes.Add(note);
                    db.SaveChanges();
                    return Json(new { message = "Сохранено", noteid = note.Id });
                } else
                {
                    db.Notes.FirstOrDefault(x => x.Id == noteId).Content = content;
                    db.SaveChanges();
                    return Json(new { message = "Сохранено", noteid = noteId });
                }
            }
        }
    }
}