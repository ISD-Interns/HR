using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models.ViewModels
{
	public class DropdownTestViewModel
	{
		public IEnumerable<Map> maps { get; set; }
		public Map OneMap { get; set; }
	}
}
