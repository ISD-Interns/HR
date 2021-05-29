using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models.ViewModels
{
	public class GamePreference
	{
		public class GamePreferenceInstance
		{
			public Game Game { get; set; }
			public bool isPreferred { get; set; }
		}
		public string username { get; set; }
		public IEnumerable<GamePreferenceInstance> Prefs { get; set; }
	}
}
