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
	public class ProfileController : BaseController<int>
	{
		//[Route("{userVarParam}/main")]
		//[Route("{" + StringConstants.DefaultModelBindKeyword + "}/main")]

        public ProfileController(HaloRunsDbContext param)
            : base(param)
        {
              
        }
		
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
			var viewStuff = this.db
				.Games

			return View(viewStuff);
		}

		[Route("GamePreferences/{gamePreference}/disable")]
		public IActionResult DisableGamePreference(User user, game gamePreference, run myRun)
		{
			return Json(0);
		}

        public override JsonResult dataTableParam()
        {
            return Json(0);
        }
	}
}
