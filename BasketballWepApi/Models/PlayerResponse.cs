using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class PlayerResponse
    {
        public int number { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string photo { get; set; }
        public long nbaAge { get; set; }
    }
}
