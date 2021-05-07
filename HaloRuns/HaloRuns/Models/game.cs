using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class game
    {
        //name , difficulty, id
        //        [DisplayName("Pay Code")]
        //[DisplayFormat(NullDisplayText = "No Pay Code")]
        //public string PayCodeName { get; set; }

        [DisplayName("name")]
        public string name { get; set; }
        [DisplayName("difficulty")]
        public string difficulty { get; set; }
        public int id { get; set; }
        public IEnumerable<map> Maps { get; set; }
        public IEnumerable<edition> Editions { get; set;}

        public ICollection<User> Users { get; set; }
        public List<user_game> UserGames { get; set; }
        public string RouteName { get; set; }

    }
}
