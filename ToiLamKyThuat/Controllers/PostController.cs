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
    public class PostController : BaseController
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
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = _repository.Create(model);
            if(result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }

        public ActionResult Update(Post model)
        {
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Update, RequestUserID);
            int result = _repository.Update(model.Id, model);
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }

        public ActionResult Delete(long ID)
        {
            string note = AppGlobal.InitString;
            int result = _repository.Delete(ID);
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }

        public ActionResult GetByID(long ID)
        {
            return Json(_repository.GetByID(ID));
        }

        public ActionResult GetAllToList()
        {
            return Json(_repository.GetAllToList());
        }

    }
}