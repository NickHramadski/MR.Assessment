using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace MR.Assessment.Web.Controllers
{
    public class AddsController : Controller
    {
        public IActionResult Index()
        {
            var model = new []
            {
                new { AdId = 1, BrandId = "Name 1", Name = "AAA", NumPages = 2, Position = "Page" },
                new { AdId = 2, BrandId = "Name 2", Name = "XXX", NumPages = 3, Position = "Cover" },
                new { AdId = 3, BrandId = "Name 3", Name = "YYY", NumPages = 4, Position = "Page" },
                new { AdId = 4, BrandId = "Name 4", Name = "MMM", NumPages = 5, Position = "Cover" },
                new { AdId = 5, BrandId = "Name 5", Name = "BBB", NumPages = 21, Position = "Page" },
            };

            return View(model);
        }

        public IActionResult Task2()
        {
            return View();
        }

        public IActionResult Task3()
        {
            return View();
        }

        public IActionResult Task4()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
