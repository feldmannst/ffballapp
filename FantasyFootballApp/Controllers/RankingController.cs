using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult RankingTool()
        {
            var dataSet = GetExpertRankings(4, 0);
            return View(dataSet);
        }

        [HttpPost]
        public JsonResult UpdatePersonalRankings(string[] rankings)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Rank");
            dt.Columns.Add("PlayerID");

            /*
            if (db.Rankings.Where(a => a.ExpertID == 8).ToList() != null)
            {
                foreach (var oldrank in db.Rankings.Where(a => a.ExpertID == 8).ToList())
                {
                    db.Rankings.Remove(oldrank);
                }
                db.SaveChanges();
            }
            */
            int i = 1;

            foreach (var rank in rankings)
            {
                dt.Rows.Add(i, rank);
            }

            
            /*
            foreach (var rank in rankings)
            {
                int playerId = Convert.ToInt32(rank);

                Ranking entry = new Ranking
                {
                    ExpertID = 8,
                    Expert = db.Experts.Where(a => a.ExpertID == 8).First(),
                    PlayerID = playerId,
                    Player = db.Players.Where(a => a.PlayerID == playerId).First(),
                    Rank = i,
                    Season = 2014
                };
                db.Rankings.Add(entry);
                i = i + 1;
            }

            db.SaveChanges();
            */
            return Json(new { rankings = rankings});
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