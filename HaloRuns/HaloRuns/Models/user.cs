using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class user
    {
        public string Username { get; set; }
        public string Region { get; set; }
        public string Twitch { get; set; }
        public int TotalPoints { get; set; }
        public int Id { get; set; }

        public IEnumerable<run> Runs { get; set; }
    }
}
