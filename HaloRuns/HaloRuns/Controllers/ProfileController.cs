﻿using HaloRuns.ModelBinders;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Helpers;
using Microsoft.EntityFrameworkCore;
using HaloRuns.Models.ViewModels;

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
			// userPref 

			/*
			  var UserRuns = this
                .db
                .Users
                .Include(u => u.Games)
                .Include(u => u.Runs)
                .ThenInclude(r => r.Map)
                .ThenInclude(m => m.Game)
                .Where(u => u.Username == "Steve")
                .First();
			 */

			// [['Steve','halo1'],['Steve','halo2'],['Steve','halo3']]
			var currUser =
					this
					.db
					.Users
					.Include(g => g.Games)
					.Include(u => u.UserGames)
					.Where(u => u.Username == user.Username) //user.Username == 'Steve'
					.First();


			//[game,bool]
			var userGamePreferences = new GamePreference
			{
				username = user.Username,
				Prefs =
					this
					.db
					.Games
					.Select(g => new GamePreference.GamePreferenceInstance
					{
						Game = g,
						isPreferred = currUser.Games.Contains(g),
					})
					.ToList()
			};

			string urlSomething = Url.RouteUrl("DisableGamePreferenceRouteName", new { });

			var allGames =
				this
				.db
				.Games
				.ToList();
			return View(userGamePreferences);
		}

		[Route("GamePreferences/{gamePreference}/disable", Name = "DisableGamePreferenceRouteName")]
		public IActionResult DisableGamePreference(User user, game gamePreference)
		{
			var User = this
				.db
				.Users
				.Include(g => g.Games)
				.Where(u => u.Username == user.Username)
				.First();

				User.Games.Remove(gamePreference);
				this.db.SaveChanges();
			
			return Json(0);
		}

		[Route("GamePreferences/{gamePreference}/enable", Name = "EnableGamePreferenceRouteName")]
		public IActionResult EnableGamePreference(User user, game gamePreference) 
		{
			var User = this
				.db
				.Users
				.Include(g => g.Games)
				.Where(u => u.Username == user.Username)
				.First();

			//db.Attach(User)
			User.Games.Add(gamePreference);
			this.db.SaveChanges();


			return Json(0);
		}

        public override JsonResult dataTableParam()
        {
            return Json(0);
        }
	}
}
