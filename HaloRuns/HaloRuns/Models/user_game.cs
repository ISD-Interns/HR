using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class user_game
    {
        public int UserId { get; set; }
        public user User { get; set; }

        public int GameId { get; set; }
        public game Game { get; set; }

    }

}
