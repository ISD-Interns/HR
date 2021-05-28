using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models.ViewModels
{
    public class RunIds
    {
        public RunIds(string mapId, string editionId, string difficultyId, string gameId) {
            this.map = mapId;
            this.edition = editionId;
            this.difficulty = difficultyId;
            this.game = gameId;
        }
        public string map{get;set;}
        public string edition{get; set;}
        public string difficulty{ get; set; }
        public string game{ get; set; }
    }
}
