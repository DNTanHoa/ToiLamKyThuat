using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToiLamKyThuat.Data.Helpers;

namespace ToiLamKyThuat.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        [Consumes("multipart/form-data")]
        public IActionResult Upload([FromForm]IFormFile file)
        {
            string note = AppGlobal.InitString;
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                string fileName = Path.GetFileNameWithoutExtension(file.FileName) + AppGlobal.DateTimeCode + fileExtension;
                string path = AppGlobal.FileFTP + Path.Combine(fileName);
                string physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
                return Json(note);
            }   
            else
            {
                note = AppGlobal.Fail + " - " + AppGlobal.CreateFail;
                return Json(note);
            }    
        }

        public IActionResult UploadDialog()
        {
            return PartialView("~/Views/Shared/_UploadDialog.cshtml");
        }

        public IActionResult BrowserDialog()
        {
            return PartialView("~/Views/Shared/_BrowserDialog.cshtml");
        }
    }
}