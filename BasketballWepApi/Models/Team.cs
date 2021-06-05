using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class Team
    {
        public List<TeamData> data { get; set; }
    }
    public class TeamData
    {
        [Key]
        public string teamId { get; set; }
        public string leagueId { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string logo { get; set; }
        public string website { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public string city { get; set; }
        public string venue { get; set; }
        public int capacity { get; set; }
        public int joinYear { get; set; }
        public int championCount { get; set; }
        public string coach { get; set; }
        public virtual LeagueData League { get; set; }
        public virtual List<PlayerData> Players { get; set; }

    }
}
