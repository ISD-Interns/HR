using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HaloRuns.ModelBinders
{
	public class BaseModelBinder<T> : IModelBinder
		where T : class
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			//var values = bindingContext.ValueProvider.GetValue(StringConstants.DefaultModelBindKeyword);
			//var values = bindingContext.ValueProvider.GetValue(nameof(T));
			var values = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);

			if (values.Length == 0)
			{
				return Task.CompletedTask;
			}

			var paramValue = values.First();


			//var dbContext = new HaloRunsDbContext();
			var dbContext = (HaloRunsDbContext)bindingContext.HttpContext.RequestServices.GetService(typeof(HaloRunsDbContext));

			var dbTableProp = typeof(HaloRunsDbContext)
				.GetProperties()
				.Where(prop => prop.PropertyType == typeof(DbSet<T>))
				.ToList();

			var dbTable = (DbSet<T>)dbTableProp.First().GetValue(dbContext);
			var targetProp = AttributeLookupHelper.CheckRequiredAttribute<RouteModelBindKeyAttribute>(typeof(T));

			//var result = dbContext.Users.Where(u => u.Username == paramValue).FirstOrDefault();
			//dbContext.Users.Where($"{targetProp.Name} == {paramValue.ToString()}");

			var items = dbTable.ToList();
			var result = items.Where(genericType => targetProp.GetValue(genericType, null).ToString() == paramValue).ToList();
			//var result = items.Where(genericType => propExpr.(genericType) == paramValue).ToList();
			//var result2 = items.Where(genericType => genericType.Field<string>("hey").Contains(paramValue)).ToList();
			if (result.Count() > 0)
			{
				bindingContext.Result = ModelBindingResult.Success(result.First());
			}
			//DependencyResolver.

			//temp
			return Task.CompletedTask;
		}
	}
}
