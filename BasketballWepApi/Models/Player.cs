using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class Player
    {
        public List<PlayerData> data { get; set; }
    }
    public class PlayerData
    {
        public string playerId { get; set; }
        public int number { get; set; }
        [Key]
        public string name { get; set; }
        public string teamId { get; set; }
        public string place { get; set; }
        public int birthday { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string photo { get; set; }
        public long nbaAge { get; set; }
        public string salary { get; set; }

        public virtual TeamData Team { get; set; }
    }
}
