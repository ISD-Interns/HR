using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models.ViewModels
{
	public class DropdownTestViewModel
	{
		public IEnumerable<map> maps { get; set; }
		public map OneMap { get; set; }
	}
}
