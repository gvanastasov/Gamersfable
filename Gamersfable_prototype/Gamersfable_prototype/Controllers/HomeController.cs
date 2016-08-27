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
            var topStories = db.StoriesLibrary.OrderByDescending(x => x.Score)
                               .Take(3)
                               .Include(s => s.Author)
                               .ToList();

            return View(topStories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "We are a newly started team - an army of One they say";

            return View();
        }
    }
}