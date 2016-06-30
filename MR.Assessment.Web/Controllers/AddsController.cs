using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Linq;

namespace MR.Assessment.Web.Controllers
{
    public class AddsController : Controller
    {
        class AddModel
        {
            public string Name { get; set; }
            public string Position { get; set; }

            public int AdId { get; set; }
            public int BrandId { get; set; }
            public int NumPages { get; set; }
        }

        private static readonly JToken Adds = JArray.FromObject(new []
        {
            new AddModel { AdId = 1, BrandId = 15, Name = "AAA", NumPages = 2, Position = "Page" },
            new AddModel { AdId = 2, BrandId = 33, Name = "BBB", NumPages = 3, Position = "Cover" },
            new AddModel { AdId = 3, BrandId = 44, Name = "YYY", NumPages = 4, Position = "Page" },
            new AddModel { AdId = 4, BrandId = 15, Name = "AAA", NumPages = 5, Position = "Cover" },
            new AddModel { AdId = 5, BrandId = 33, Name = "BBB", NumPages = 21, Position = "Page" },
        });

        public IActionResult Index()
        {
            //var class1 = new MR.Assessment.Data.Interaces.Class1();
            return View(Adds);
        }

        public IActionResult Task2()
        {
            return View(Adds);
        }

        public IActionResult Task3()
        {
            return View(Adds);
        }

        public IActionResult Task4()
        {
            return View(Adds);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
