using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class edition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GameId { get; set; }

        public game Game {get; set; }

        public int PlatfromId { get; set; }
        
    }
}
