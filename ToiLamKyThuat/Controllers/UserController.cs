using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToiLamKyThuat.Data.Enums;
using ToiLamKyThuat.Data.Helpers;
using ToiLamKyThuat.Data.Models;
using ToiLamKyThuat.Data.Respositories;
using ToiLamKyThuat.Models;

namespace ToiLamKyThuat.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRespository _repository;

        public UserController(IUserRespository respository)
        {
            _repository = respository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Detail(int ID)
        {
            var model = _repository.GetByID(ID);
            return View(model);
        }

        public ActionResult Create(User model)
        {
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = _repository.Create(model);
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

        public ActionResult Update(User model)
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

        public ActionResult LoginSubmit(UserViewModel model)
        {
            if(_repository.IsValid(model.Username, model.Password))
            {
                return Json(AppGlobal.Success + " - " + AppGlobal.RedirectDefault);
            }
            else
            {
                return Json(AppGlobal.Fail + " - " + AppGlobal.LoginFail);
            }
        }

        public ActionResult SaveChange(User model)
        {
            string note = AppGlobal.InitString;
            int result = 0;
            if (model.Id > 0)
            {
                model.Initialization(InitType.Update, RequestUserID);
                model.Password = SecurityHelper.Encrypt(model.Code, model.Password);
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
                model.Password = SecurityHelper.Encrypt(model.Code, model.Password);
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
    }
}