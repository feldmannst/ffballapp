using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FantasyFootballApp.Models;

namespace FantasyFootballApp.Controllers
{
    public class TeamController : Controller
    {
        FFBallDatabaseEntities db = new FFBallDatabaseEntities();
        //
        // GET: /Team/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult TeamList()
        {
            try
            {
                IQueryable<Team> teams = db.Teams;

                List<Team> teamlist = teams.OrderBy(a => a.TeamName).ToList();

                return Json(new
                    {
                        Result = "OK",
                        Records = (from t in teamlist
                                  select new 
                                  {
                                      TeamID = t.TeamID,
                                      TeamName = t.TeamName,
                                      Abbreviation = t.Abbreviation,
                                      FirstName = t.FirstName,
                                      State = t.State,
                                      Conference = t.Conference,
                                      Division = t.Division
                                  })
                    });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateTeam(Team team)
        {
            try
            {
                Team entry = new Team
                {
                    TeamID = team.TeamID,
                    TeamName = team.TeamName,
                    Abbreviation = team.Abbreviation,
                    FirstName = team.FirstName,
                    State = team.State,
                    Conference = team.Conference,
                    Division = team.Division
                };

                db.Teams.Add(entry);
                db.SaveChanges();
                int lastID = db.Teams.Max(a => a.TeamID);
                Team addedTeam = db.Teams.Where(a => a.TeamID == lastID).Single();
                return Json(new
                    {
                        Result = "OK",
                        Record = new
                        {
                            TeamID = addedTeam.TeamID,
                            TeamName = addedTeam.TeamName,
                            Abbreviation = addedTeam.Abbreviation,
                            FirstName = addedTeam.FirstName,
                            State = addedTeam.State,
                            Conference = addedTeam.Conference,
                            Division = addedTeam.Division
                        }
                    });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateTeam(Team team)
        {
            try
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteTeam(int teamid)
        {
            try
            {
                Team team = db.Teams.Find(teamid);
                db.Teams.Remove(team);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
	}
}