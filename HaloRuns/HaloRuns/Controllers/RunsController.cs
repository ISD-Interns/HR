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
        /*
        public RunsDatatableParam SetRunTable(run r) {
            var rTable = new RunsDatatableParam();
            rTable.Date = r.Date;
            rTable.Time = r.Time;
            rTable.Id = r.Id;
            return rTable;
        }
        */
        public IActionResult Index()
        {
            /*var list = db
                .Runs
                .ToList()
                .Select(r => new RunsDatatableParam { Date = r.Date, Time = r.Time, Id = r.Id});
            */
                
            return View();
        }
        public ViewResult Table()
        {
            return View();

        }
        /*
        public class RunsDatatableParam
        {
            public int Date { get; set; }

            public int Time{ get; set; }

            public int Id { get; set; }

        }
        */
        public override JsonResult dataTableParam()
        {
            return generateDataTablesParam<RunsDatatableParam>();
        }

    }

}
