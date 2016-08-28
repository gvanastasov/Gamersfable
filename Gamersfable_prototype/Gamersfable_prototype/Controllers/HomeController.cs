using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamersfable_prototype.Models;
using System.Data.Entity;

namespace Gamersfable_prototype.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var stories = new StoriesViewModel();
            stories.top3 = db.Stories.OrderByDescending(x => x.Score)
                               .Take(3)
                               .Include(s => s.Author)
                               .ToList();

            stories.last10 = db.Stories.OrderByDescending(x => x.Date)
                                           .Take(10)
                                           .ToList();

            return View(stories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "We are a newly started team - an army of One they say";

            return View();
        }
    }
}