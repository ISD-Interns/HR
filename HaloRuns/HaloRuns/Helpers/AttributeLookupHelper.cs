using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HaloRuns.Helpers
{
	public static class AttributeLookupHelper
	{
		public static PropertyInfo CheckRequiredAttribute<T>(Type type)
			where T : Attribute
		{
			var members = type.GetProperties().Where(prop => prop.GetCustomAttributes<T>().Count() > 0);
			if (members.Count() != 1)
			{
				throw new InvalidOperationException($"class {type.Name} must have one property with {typeof(T).Name}");
			}
			return members.First();
		}
	}
}
