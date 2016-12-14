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
                return View(new NotesViewModel
                {
                    Notes = db.Notes.OrderByDescending(x => x.CreateData).ToList(),
                });
            }
        }

        [HttpPost]
        public ActionResult saveNote(int? noteId, string content)
        {
            using (var db = new ApplicationDbContext())
            {
                if (noteId == null)
                {
                    string userId = User.Identity.GetUserId();
                    Note note = new Note
                    {
                        Content = content,
                        CreateData = DateTime.Now,
                        ApplicationUser = db.Users.FirstOrDefault(x => x.Id == userId)
                    };
                    db.Notes.Add(note);
                    db.SaveChanges();
                    return Json(new { message = "Сохранено", noteid = note.Id });
                }
                else
                {
                    db.Notes.FirstOrDefault(x => x.Id == noteId).Content = content;
                    db.SaveChanges();
                    return Json(new { message = "Сохранено", noteid = noteId });
                }
            }
        }
        public ActionResult deleteNote(int noteId)
        {
            using (var db = new ApplicationDbContext())
            {
                string userId = User.Identity.GetUserId();
                var note = db.Notes.Find(noteId);
                if (note.ApplicationUser == db.Users.FirstOrDefault(x => x.Id == userId))
                {
                    db.Notes.Remove(note);
                    db.SaveChanges();
                }

                return Json(new { message = "Удалено" });
            }
        }

        [HttpPost]
        public ActionResult moveNote(int nextnote, int currentnote, int prevnote)
        {
            using (var db = new ApplicationDbContext())
            {
                Note current = db.Notes.Find(currentnote),
                    next = db.Notes.Find(nextnote),
                    prev = db.Notes.Find(prevnote);

                current.CreateData = DateTime.FromBinary(prev.CreateData.ToBinary() + (next.CreateData.ToBinary() - prev.CreateData.ToBinary()) / 2);
                db.SaveChanges();
            }
            return Content("");
        }
    }
}