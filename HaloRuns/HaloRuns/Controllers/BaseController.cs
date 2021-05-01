using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaloRuns.Controllers
{
    public abstract class BaseController<T> : Controller
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
        public class RunsDatatableParam
        {
            public int Id { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Name { get; set; }

        }

        [HttpPost]
        public IActionResult DataTablesCallback()
        {
            //string a = Request.Form["start"];
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            var UserRuns = this
                .db
                .Runs
                .Include(r => r.Edition)
                .Where(r => r.Id >= start && r.Id <= (start + length))
                .ToList()
                .Select(r => new RunsDatatableParam {
                    Date = DateTimeOffset.FromUnixTimeSeconds(r.Date).UtcDateTime.ToString("d"),
                    Time = TimeSpan.FromSeconds(r.Time).ToString(),
                    Id = r.Id,
                    Name = r.Edition.Name
                });
            int CountOfUserRuns = UserRuns.Count();
            var x = new
            {
                draw = int.Parse(this.Request.Form["draw"]),
                recordsTotal = CountOfUserRuns,
                recordsFiltered = CountOfUserRuns,
                data = UserRuns
            };
            return Json(x);
        }
        protected List<Func<T, object>> lambdas;

        protected JsonResult generateDataTablesParam<TdataTableType>(){
            var columns = typeof(TdataTableType).GetProperties();//.Select(a => new { data = a.Name, autowidth = true, searchable = true })

            return Json(new {
                bPaginate = true,
                bLengthChange = false,
                bFilter = true,
                processing = true,
                serverSide = true,
                ajax = new {
                    url = Url.Action("DataTablesCallback", "runs"),
                    type = "POST",
                    datatype = "json",
                },
                bInfo = false,
                bAutoWidth = true,
                order = new object[] { new object[] { 1, "asc" } },
                columns = typeof(TdataTableType).GetProperties().Select(a => new{ data = a.Name.ToLower(), autowidth = true, searchable = true}),
                pageLength = 3,
            });
        }

        public abstract JsonResult dataTableParam();
    }
}
