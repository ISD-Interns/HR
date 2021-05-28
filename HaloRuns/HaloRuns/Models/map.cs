using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class map
    {
        [DisplayName("name")]
        public string name { get; set; }
        public int id { get; set; }
        public int GameId { get; set; }
        public game Game { get; set; }
        public IEnumerable<run> Runs { get; set; }

    }
}
