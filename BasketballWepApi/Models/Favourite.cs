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
        public string UserId { get; set; }
        public List<string> MatchesId { get; set; }
    }
}
