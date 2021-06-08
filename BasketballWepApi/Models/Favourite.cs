using BasketballWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWepApi.Models
{
    public class Favourite
    {
        [Key]
        public bool MatchIsStarted { get; set; }
        public bool MatchIsEnded { get; set; }
        public MatchData matchData { get; set; }
    }
}
