using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamersfable_prototype.Models;
using System.Net;

namespace Gamersfable_prototype.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Category/
        public ActionResult Category(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var stories = db.Stories.Where(s => s.Game_Id == id);
            if (stories == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoriesGameTitle = db.Games.FirstOrDefault(g => g.Id == id).Title;
            return View(stories.ToList());
        }
    }
}