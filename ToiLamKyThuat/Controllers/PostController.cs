using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToiLamKyThuat.Data.Enums;
using ToiLamKyThuat.Data.Helpers;
using ToiLamKyThuat.Data.Models;
using ToiLamKyThuat.Data.Respositories;

namespace ToiLamKyThuat.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRespository _repository;

        public PostController(IPostRespository respository)
        {
            _repository = respository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int ID)
        {
            var model = _repository.GetByID(ID);
            return View();
        }

        public ActionResult Create(Post model)
        {
            model.Initialization(InitType.Insert, )
        }
    }
}