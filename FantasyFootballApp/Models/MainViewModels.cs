using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyFootballApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Ranking> TopPlayers { get; set; }
    }
}