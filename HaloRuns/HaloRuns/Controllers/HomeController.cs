using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HaloRuns.Models;
using Microsoft.EntityFrameworkCore;

namespace HaloRuns.Controllers
{
    public class HomeController : BaseController
    {

        //private readonly ILogger<HomeController> _logger;

        public HomeController(HaloRunsDbContext param)
            : base(param)
        {
              
        }

        public IActionResult Index()
        {
            /*
             *  return
                this
                .timeOffDb
                .Requests
                .Include(r => r.Employee)
                .ThenInclude(e => e.Manager)
                .Where(r=> ids.Contains(r.Id));
             */
            //query for username and store all runs in a var
            //where usernam = 'steve'
            var UserRuns = this
                .db
                .Users
                .Include(u => u.Runs)
                .ThenInclude(r => r.Map)
                .ThenInclude(m => m.Game)
                .Where(u => u.Username == "Steve")
                .ToList();
                //.First()
            //var UserRuns
                //.Runs;
                
            //store the game of a run in a variable 
            //
            
                
                
            return View(this.user);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ViewResult Table() 
        {

            return View();
        }
    }
}
