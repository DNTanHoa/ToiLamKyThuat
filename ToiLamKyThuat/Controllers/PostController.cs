using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.SEOHelper.Sitemap;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _environment;

        public PostController(IPostRespository respository, IWebHostEnvironment environment)
        {
            _repository = respository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int ID)
        {
            var model = _repository.GetByID(ID);
            if(model != null)
                return View(model);
            return View(new Post());
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

        public ActionResult GetByPageAndPageSizeToList(int Page, int PageSize)
        {
            return Json(_repository.GetByPageAndPageSizeToList(Page, PageSize));
        }

        public ActionResult GetPostDataTranfersByPageAndPageSizeToList(int Page, int PageSize)
        {
            return Json(_repository.GetPostDataTranfersByPageAndPageSizeToList(Page, PageSize));
        }

        public ActionResult SaveChange(Post model)
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

        public ActionResult CreateSitemap()
        {
            string note = AppGlobal.InitString;
            var items = _repository.GetSitemapDataTranferByCodeAndConfig("ToiLamKyThuat", "Menu");
            var sitemapNodes = new List<SitemapNode>();
            foreach(var item in items)
            {
                sitemapNodes.Add(new SitemapNode
                {
                    Url = item.IsPost != 0 ? AppGlobal.Domain + item.MetaTitle + "-" + item.ID + ".html" : AppGlobal.Domain + item.MetaTitle,
                    LastModified = ((DateTime)item.CreateDate).ToLocalTime(),
                    Priority = 1,
                    Frequency = SitemapFrequency.Daily
                });
            }
            new SitemapDocument().CreateSitemapXML(sitemapNodes, _environment.WebRootPath + AppGlobal.SitemapFTP);
            note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            return Json(note);
        }
    }
}