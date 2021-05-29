using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Helpers;

namespace HaloRuns.Models
{
    public class Game
    {
        //name , difficulty, id
        //        [DisplayName("Pay Code")]
        //[DisplayFormat(NullDisplayText = "No Pay Code")]
        //public string PayCodeName { get; set; }

        [DisplayName("name")]
        public string name { get; set; }
        public int id { get; set; }
        public IEnumerable<Map> Maps { get; set; }
        public IEnumerable<Edition> Editions { get; set;}

        public ICollection<User> Users { get; set; }
        public List<user_game> UserGames { get; set; }
        [RouteModelBindKey]
        public string RouteName { get; set; }

    }
}
