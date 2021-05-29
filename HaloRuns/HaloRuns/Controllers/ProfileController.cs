using HaloRuns.ModelBinders;
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
			return View(user);
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
		public IActionResult DisableGamePreference(User user, Game gamePreference)
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
		public IActionResult EnableGamePreference(User user, Game gamePreference) 
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

		[Route("NewRun/Submit", Name = "RunSubmit")]
		[HttpPost]
		public JsonResult RunPost(User User, [FromForm] RunIds RunIds) {
			return Json(RunIds);
		}

		[Route("NewRun")]
		public IActionResult RunEntry(User user) {
			var User = this
					.db
					.Users
					.Where(u => u.Username == user.Username)
					.First();
			var games = 
				new List<Game> { new Game { name = "&&&&&&&&&&&&" } }.Concat(
					this
						.db
						.Games
						.ToList()
					).ToList();

			var difficulties = this
					.db
					.Difficulty
					.Where(d => d.Id <= 4)
					.ToList();
			//string username = User.Username;
			var Form = new RunForm(user, games, difficulties);
			return View(Form);
		}

		[Route("NewRun/{game}/editions", Name = "RunEntryFetchEditionRouteName")]
		public IActionResult RunEntryFetchEdition(Game game)
		{
			var Editions = this
				.db
				.Editions
				.Where(g => g.GameId == game.id)
				.ToList();

			return Json(Editions);
		}

		[Route("NewRun/{game}/maps", Name = "RunEntryFetchMapRouteName")]
		public IActionResult RunEntryFetchMap(Game game)
		{
			var Maps = this
				.db
				.Maps
				.Where(m => m.GameId == game.id)
				.ToList();

			return Json(Maps);
		}

		[Route("NewRun/GetRunInstance")]
		public Run GetRunInstance(User User, Difficulty Difficulty, Map Map, int Time, Edition Edition) {
			int Date = 0;
			var a = new Run();
			a.User = User;
            a.Date = Date;
			a.Difficulty = Difficulty;
			a.Map = Map;
			a.Time = Time;
			a.Edition = Edition;
			return a;
		}

		public override JsonResult dataTableParam()
        {
            return Json(0);
        }
	}
}
