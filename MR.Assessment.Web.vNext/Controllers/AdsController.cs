using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MR.Assessment.Web.Services;
using Newtonsoft.Json.Linq;

namespace MR.Assessment.Web.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdsGridManager _adsManager;
        private readonly IBrandsGridManager _brandsManager;

        public AdsController(IAdsGridManager adsManager, IBrandsGridManager brandsManager)
        {
            _adsManager = adsManager;
            _brandsManager = brandsManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _adsManager.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Task2()
        {
            var data = await _adsManager.GetAllCoverPosition();
            return View(data);
        }

        public async Task<IActionResult> Task3()
        {
            var data = await _adsManager.GetTopAdsByPageCoverageDistinctByBrand();
            return View(data);
        }

        public async Task<IActionResult> Task4()
        {
            var data = await _brandsManager.GetTopBrandsByPageCoverage();
            return View(data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
