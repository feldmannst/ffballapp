using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantasyFootballApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Ranking> TopPlayers { get; set; }
    }

    public class RankingViewModel
    {
        public SelectList ExpertList { get; set; }

        public SelectList AllPositions { get; set; }

        public RankingViewModel(FFBallDatabaseEntities db)
        {
            List<SelectListItem> allExperts = new List<SelectListItem>();

            List<SelectListItem> allPositions = new List<SelectListItem>();

            foreach (var expert in db.Experts)
            {
                allExperts.Add(new SelectListItem { Text = expert.ExpertName, Value = expert.ExpertID.ToString() });
            }

            foreach (var pos in db.Positions)
            {
                allPositions.Add(new SelectListItem { Text = pos.Abbreviation, Value = pos.PositionID.ToString() });
            }

            AllPositions = new SelectList(allPositions, "Value", "Text");
            ExpertList = new SelectList(allExperts, "Value", "Text");
        }
    }
}