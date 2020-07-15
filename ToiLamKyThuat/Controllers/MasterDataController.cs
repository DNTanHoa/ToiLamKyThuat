using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToiLamKyThuat.Data.Enums;
using ToiLamKyThuat.Data.Helpers;
using ToiLamKyThuat.Data.Models;
using ToiLamKyThuat.Data.Respositories;

namespace ToiLamKyThuat.Controllers
{
    public class MasterDataController : BaseController
    {
        private readonly IMasterDataRespository _repository;

        public MasterDataController(IMasterDataRespository respository)
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
            return View(model);
        }

        public ActionResult Create(MasterData model)
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

        public ActionResult Update(MasterData model)
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

        public ActionResult SaveChange(MasterData model)
        {
            string note = AppGlobal.InitString;
            int result = 0;
            if (model.Id > 0)
            {
                model.Initialization(InitType.Update, RequestUserID);
                result = _repository.Update(model.Id, model);
                if (result > 0)
                {
                    note = AppGlobal.Success + " - " + AppGlobal.EditSuccess;
                }
                else
                {
                    note = AppGlobal.Success + " - " + AppGlobal.EditFail;
                }
            }
            else
            {
                model.Initialization(InitType.Insert, RequestUserID);
                result = _repository.Create(model);
                if (result > 0)
                {
                    note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
                }
                else
                {
                    note = AppGlobal.Success + " - " + AppGlobal.CreateFail;
                }
            }
            return Json(note);
        }

        public ActionResult GetByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Json(_repository.GetAllToList());
            return Json(_repository.GetByKeyword(keyword));
        }

        public ActionResult GetByConfigAndCode(string Config, string Code)
        {
            return Json(_repository.GetByConfigAndCode(Config, Code));
        }

        public ActionResult GetByConfigAndCodeAndKeyword(string Config, string Code, string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
                return Json(_repository.GetByConfigAndCode(Config, Code));
            return Json(_repository.GetByConfigAndCodeAndKeyword(Config, Code, keyword));
        }

    }
}