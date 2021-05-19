using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
	public class ManyToManyModel<T>
	{
        public List<T> __ManyToManyModel_joiningProperty { get; set; }
	}

	public class ManyToManyModel<T1, T2>
	{
        public List<T1> __ManyToManyModel_joiningProperty1 { get; set; }
        public List<T2> __ManyToManyModel_joiningProperty2 { get; set; }
	}
}
