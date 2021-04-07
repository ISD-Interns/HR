using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaloRuns.Controllers
{
    public abstract class BaseController : Controller
    {
        public HaloRunsDbContext db;
        protected user user;
        public BaseController(HaloRunsDbContext param)
        {
            this.db = param;
            this.user = 
                db
                .Users
                //.Include(u => u.Game)
                .Where(t => t.Id == 1)
                .First();
        }

        [HttpPost]
        public IActionResult DataTablesCallback() 
        {
            return Json(0);
            //string a = Request.Form["start"];
            int start = int.Parse(Request.Query["start"]);
            int length = int.Parse(Request.Query["length"]);
            var UserRuns = this
                .db
                .Runs
                .Where(r => r.Id >= start && r.Id <= (start + length))
                .ToList();
            return Json(0);
        }
    }
}
