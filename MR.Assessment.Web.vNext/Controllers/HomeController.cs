using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace MR.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Redirect to Adds controller by default
            return RedirectToAction("Index", "Adds");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
