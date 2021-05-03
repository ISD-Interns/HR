using HaloRuns.ModelBinders;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Helpers;

namespace HaloRuns.Controllers
{
	[Route("/customroute/profiles2/{user}")]
	public class ProfileController : Controller
	{
		//[Route("{userVarParam}/main")]
		//[Route("{" + StringConstants.DefaultModelBindKeyword + "}/main")]
		
		[Route("main")]
		public IActionResult Index(
			//[ModelBinder(typeof(BaseModelBinder<User>))]
			User user
			)
		{
			return View();
		}


		[Route("GamePreferences")]
		public IActionResult GamePreferences(User user)
		{
			return View(user);
		}

		[Route("GamePreferences/{gamePreference}/disable")]
		public IActionResult DisableGamePreference(User user, game gamePreference, run myRun)
		{
			return Json(0);
		}
	}
}
