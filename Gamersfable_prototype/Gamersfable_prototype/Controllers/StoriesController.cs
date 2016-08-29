using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gamersfable_prototype.Models;
using Microsoft.AspNet.Identity;

namespace Gamersfable_prototype.Controllers
{
    public class StoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stories/Index/guid
        public ActionResult Index(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stories = db.Stories.Include(s => s.Game).Where(s => s.Game.Id == id).ToList();
            if (stories == null)
            {
                return HttpNotFound();
            }

            ViewBag.StoriesGameTitle = db.Games.FirstOrDefault(x => x.Id == id).Title.ToString();
            ViewBag.UserID = db.Users.FirstOrDefault(u=> u.UserName == User.Identity.Name).Id;
            
            return View(stories);
        }

        // GET: Stories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Include(s=>s.Author).Include(s=>s.Game).ToList().Find(x=> x.Id == id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: Stories/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new StoryCreateViewModel();
            model.Games = new SelectList(db.Games, "Id", "Title");
            return View(model);
        }

        // POST: Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Create([Bind(Include = "Title,Body,GameID")] StoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var story = new Story();
                story.Title = model.Title;
                story.Body = model.Body;
                story.Game_Id = model.GameID;
                story.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

                db.Stories.Add(story);
                db.SaveChanges();
                return RedirectToAction("Details", "Stories", new { id = story.Id });
            }

            return View(model);
        }

        // GET: Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if(User.Identity.GetUserId() != db.Stories.Find(id).Author_Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Date,Score")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        // GET: Stories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = db.Stories.Find(id);
            db.Stories.Remove(story);
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
