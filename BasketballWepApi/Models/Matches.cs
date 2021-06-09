using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class Matches
    {
        public List<MatchData> data { get; set; }
    }
    public class MatchData
    {
        [Key]
        public string matchId { get; set; }
        public string leagueId { get; set; }
        public string leagueName { get; set; }
        public int quarterCount { get; set; }
        public int matchTime { get; set; }
        public int status { get; set; }
        public string quarterRemainTime { get; set; }
        public string homeId { get; set; }
        public string homeName { get; set; }
        public int homeRank { get; set; }
        public int awayId { get; set; }
        public string awayName { get; set; }
        public int awayRank { get; set; }
        public int homeScore { get; set; }
        public int awayScore { get; set; }
        public int overTimeCount { get; set; }
        public string leagueSeason { get; set; }
        public int matchType { get; set; }
        public bool hasStats { get; set; }
        public string explain { get; set; }
        public string roundType { get; set; }
        public string group { get; set; }
        public bool neutral { get; set; }
        public virtual LeagueData League { get; set; }
    }
}
