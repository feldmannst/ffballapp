using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantasyFootballApp.Models
{
    public class EditPlayerViewModel
    {
        public SelectList AllTeams { get; set; }

        public SelectList AllPositions { get; set; }

        public EditPlayerViewModel(FFBallDatabaseEntities db)
        {
            List<SelectListItem> allTeamsList = new List<SelectListItem>();
            List<SelectListItem> allPositionList = new List<SelectListItem>();

            foreach(var team in db.Teams)
            {
                allTeamsList.Add(new SelectListItem { Text = team.TeamName, Value = team.TeamID.ToString() });
            }

            foreach(var pos in db.Positions)
            {
                allPositionList.Add(new SelectListItem { Text = pos.Abbreviation, Value = pos.PositionID.ToString() });
            }

            AllTeams = new SelectList(allTeamsList, "Value", "Text");
            AllPositions = new SelectList(allPositionList, "Value", "Text");
        }
    }
}