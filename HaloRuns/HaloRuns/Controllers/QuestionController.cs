using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HaloRuns.Models;


/*
 * 
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;
 */
namespace HaloRuns.Controllers
{
    public class QuestionController : BaseController<int>
    {
        public QuestionController(HaloRunsDbContext param)
            : base(param)
        {

        }

        public ViewResult Table()
        {

            return View();
        }

        public override JsonResult dataTableParam()
        {
            return Json(0);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form([FromForm] Question Data) {
            return View(Data);
        }
    }
}
