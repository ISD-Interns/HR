using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class Map
    {
        [DisplayName("name")]
        public string name { get; set; }
        [Helpers.RouteModelBindKey]
        public int id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public IEnumerable<Run> Runs { get; set; }

        /*
		public override string ToString()
		{
            return this.name;
		}
        */
	}
}
