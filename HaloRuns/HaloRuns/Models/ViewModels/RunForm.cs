using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models.ViewModels
{
    public class RunForm
    {
        public RunForm(user someone, List<map> maps, List<edition> editions, List<game> games) {
            this.user = someone;
            this.maps = maps;
            this.editions = editions;
            this.games = games;
        }

        [DisplayName("username")]
        public user user { get; set;}
        public List<map> maps { get; set; }
        public List<edition> editions { get; set; }
        public List<game> games { get; set; }
        //public string Username { get; set; }
        //public int Date { get; set; }
        //[DisplayName("time")]
        //public int Time { get; set; }
        //[DisplayName("edition")]
        //public int EditionId { get; set; }
        //public int Id { get; set; }
        //[DisplayName("difficulty")]
        //public int DifficultyId { get; set; }
        //public string Url { get; set; }
        //public int MapId { get; set; }
        //public map Map { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        //public edition Edition { get; set; }
    }
}
