using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaloRuns.Controllers
{
    public class RunsController : BaseController
    {
        public RunsController(HaloRunsDbContext param)
            : base(param)
        {

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
