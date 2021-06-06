using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models.ViewModels
{
    public class RunForm
    {
        public RunForm()
        {
        }

        public RunForm(User someone, List<Game> games, List<Difficulty> difficulties)
        {
            this.user = someone;
            this.games = games;
            this.difficulties = difficulties;

        }

        [DisplayName("username")]
        public User user { get; set;}
        public List<Difficulty> difficulties { get; set; }
        public List<Game> games { get; set; }
        public int GameId { get; set; }

        public Run run { get; set;}

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
