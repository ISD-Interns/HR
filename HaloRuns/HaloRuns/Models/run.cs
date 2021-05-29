using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class Run
    {
        public int Date { get; set; }
        [DisplayName("time")]
        public int Time { get; set; }
        [DisplayName("edition")]
        public int EditionId { get; set; }
        public int Id { get; set; }
        [DisplayName("difficulty")]
        public int DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Url { get; set; }
        public int MapId { get; set; }
        public Map Map { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Edition Edition { get; set;}
        public int GameId { get; set; }
    }
}
