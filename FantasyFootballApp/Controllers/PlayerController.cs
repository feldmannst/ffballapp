using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FantasyFootballApp.Models;

namespace FantasyFootballApp.Controllers
{
    public class PlayerController : Controller
    {
        FFBallDatabaseEntities db = new FFBallDatabaseEntities();
        //
        // GET: /Player/
        public ActionResult Index()
        {
            EditPlayerViewModel viewModel = new EditPlayerViewModel(db);
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult PlayerList(int? teamdd, int? positiondd, int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                int recordCount;
                IQueryable<Player> players = db.Players;

                recordCount = players.Count();

                if (teamdd != null)
                    players = players.Where(a => a.TeamID == teamdd);

                if (positiondd != null)
                    players = players.Where(a => a.PositionID == positiondd);

                List<Player> playerlist = players.OrderBy(a => a.PlayerName).Skip(jtStartIndex).Take(jtPageSize).ToList();

                return Json(new
                {
                    Result = "OK",
                    Records = (from t in playerlist
                               select new
                               {
                                   PlayerID = t.PlayerID,
                                   PlayerName = t.PlayerName,
                                   Nickname = t.Nickname,
                                   PositionID = t.PositionID,
                                   TeamID = t.TeamID,
                                   Retired = t.Retired
                               }),
                    TotalRecordCount = recordCount
                });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreatePlayer(Player player)
        {
            try
            {
                Player entry = new Player
                {
                    PlayerID = player.PlayerID,
                    PlayerName = player.PlayerName,
                    Nickname = player.Nickname,
                    PositionID = player.PositionID,
                    TeamID = player.TeamID,
                    Retired = player.Retired,
                    Team = db.Teams.Find(player.TeamID),
                    Position = db.Positions.Find(player.PositionID)
                };

                db.Players.Add(entry);
                db.SaveChanges();
                int lastID = db.Players.Max(a => a.PlayerID);
                Player addedPlayer = db.Players.Where(a => a.PlayerID == lastID).Single();
                return Json(new
                {
                    Result = "OK",
                    Record = new
                    {
                        PlayerID = addedPlayer.PlayerID,
                        PlayerName = addedPlayer.PlayerName,
                        Nickname = addedPlayer.Nickname,
                        PositionID = addedPlayer.PositionID,
                        TeamID = addedPlayer.TeamID,
                        Retired = addedPlayer.Retired
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdatePlayer(Player player)
        {
            try
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeletePlayer(int playerid)
        {
            try
            {
                Player player = db.Players.Find(playerid);
                db.Players.Remove(player);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetTeams()
        {
            try
            {
                var teams = db.Teams.Select(a => new { DisplayText = a.TeamName, Value = a.TeamID });
                return Json(new { Result = "OK", Options = teams });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetPositions()
        {
            try
            {
                var positions = db.Positions.Select(a => new { DisplayText = a.Abbreviation, Value = a.PositionID });
                return Json(new { Result = "OK", Options = positions });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}