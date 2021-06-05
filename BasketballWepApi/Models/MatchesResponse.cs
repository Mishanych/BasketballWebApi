using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class MatchesResponse
    {
        public string matchId { get; set; }
        public string leagueId { get; set; }
        public string leagueName { get; set; }
        public int quarterCount { get; set; }
        public int matchTime { get; set; }
        public int status { get; set; }
        public string quarterRemainTime { get; set; }
        public string homeName { get; set; }
        public string awayName { get; set; }
        public int homeScore { get; set; }
        public int awayScore { get; set; }
        public string leagueSeason { get; set; }
        public int matchType { get; set; }
        public string roundType { get; set; }
        public string group { get; set; }
    }
}
