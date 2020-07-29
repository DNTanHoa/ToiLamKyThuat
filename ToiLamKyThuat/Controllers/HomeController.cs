using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToiLamKyThuat.Data.Models;
using ToiLamKyThuat.Data.Respositories;
using ToiLamKyThuat.Models;

namespace ToiLamKyThuat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPostRespository _respository;

        private readonly IMasterDataRespository _masterDataRespository;

        public HomeController(ILogger<HomeController> logger, IPostRespository respository, IMasterDataRespository masterDataRespository)
        {
            _logger = logger;
            _respository = respository;
            _masterDataRespository = masterDataRespository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int ID)
        {
            var model = _respository.GetByID(ID);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult IndexByMasterData(string MetaTitle)
        {
            var model = _masterDataRespository.GetByMetaTitle(MetaTitle) ?? new MasterData();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
