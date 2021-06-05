using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class Leagues
    {
        public List<LeagueData> data { get; set; }
    }


    public class LeagueData
    {
        [Key]
        public string leagueId { get; set; }
        public string leagueName { get; set; }
        public string leagueShortName { get; set; }
        public string leagueKind { get; set; }

        public virtual List<MatchData> Matches { get; set; }
        public virtual List<TeamData> Teams { get; set; }
    }
}
