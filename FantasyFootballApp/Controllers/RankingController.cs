using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FantasyFootballApp.Models;

namespace FantasyFootballApp.Controllers
{
    public class RankingController : Controller
    {
        FFBallDatabaseEntities db = new FFBallDatabaseEntities();
        //
        // GET: /Ranking/
        public ActionResult Index()
        {
            RankingViewModel viewModel = new RankingViewModel(db);
            return View(viewModel);
        }

        public PartialViewResult DisplayExpertRankings(int? expertid, int positionid = 0)
        {
            if (expertid == null)
                expertid = 5;

            var dataSet = GetExpertRankings(expertid, positionid);
            ViewBag.ExpertName = db.Experts.Find(expertid).ExpertName.ToString();
            return PartialView("_RankingTable", dataSet);
        }

        private List<Ranking> GetExpertRankings(int? expertid, int? positionid)
        {
            IQueryable<Ranking> rankings;

            rankings = db.Rankings.Where(a => a.ExpertID == expertid);

            if (positionid != 0)
            {
                rankings = rankings.Where(a => a.Player.Position.PositionID == positionid);
            }

            var dataSet = rankings.OrderBy(a => a.Rank).ToList();

            return dataSet;
        }
	}
}