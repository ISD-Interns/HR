using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaloRuns.Controllers
{
    public class RunsController : BaseController<run>
    {
        public RunsController(HaloRunsDbContext param)
            : base(param)
        {
            //user.name, Map.name, Time

            lambdas = new List<Func<run, object>> { 
                run => run.User.Username,
                run => run.Map.name,
                run => run.Time,
            }; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Table()
        {

            return View();

        }



    }
}
