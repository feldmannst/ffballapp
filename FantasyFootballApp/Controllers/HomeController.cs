using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FantasyFootballApp.Models;

namespace FantasyFootballApp.Controllers
{
    public class HomeController : Controller
    {
        FFBallDatabaseEntities db = new FFBallDatabaseEntities();
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            var players = db.Rankings.Where(a => a.ExpertID == 5).OrderBy(a => a.Rank).ToList();
            var playerList = players.Take(10).ToList();
            viewModel.TopPlayers = playerList;
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}