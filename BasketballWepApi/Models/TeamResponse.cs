using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballWebApi.Models
{
    public class TeamResponse
    {
        public string name { get; set; }
        public string shortName { get; set; }
        public string logo { get; set; }
        public string website { get; set; }
        public string division { get; set; }
        public string city { get; set; }
        public int championCount { get; set; }
        public string coach { get; set; }
    }
}
