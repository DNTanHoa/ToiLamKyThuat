﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToiLamKyThuat.Models;

namespace ToiLamKyThuat.Controllers
{
    public class BaseController : Controller
    {
        public int RequestUserID
        {
            get
            {
                int.TryParse(Request.Cookies["UserID"], out int result);
                return result;
            }
        }

        public IActionResult ConfirmDialog(ConfirmObjectViewModel model)
        {
            return PartialView("~/Views/Shared/_ConfirmDialog.cshtml", model);
        }

        
    }
}