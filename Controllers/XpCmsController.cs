﻿using BaoAdm.Models;
using BaoAdm.Services;
using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaoAdm.Controllers
{
    //CMS base controller, abstract class
    abstract public class XpCmsController : BaseCtrl 
    {
        /// <summary>
        /// map to CmsTypeEstr
        /// </summary>
        public string CmsType = "";

        /// <summary>
        /// for FileName input field
        /// </summary>
        public string DirUpload = "";    //upload dir, no right slash

        /// <summary>
        /// cms edit model
        /// </summary>
        public CmsEditDto EditDto = null!;

        //use shared view
        public ActionResult Read()
        {			
            //ViewBag.ProgName = ProgName;
            ViewBag.CmsType = CmsType;
            return View("/Views/XpCms/Read.cshtml", EditDto); //public view
        }

        //read rows with cmsType
        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpCmsRead(CmsType).GetPageA(Ctrl, dt));
        }

        private XpCmsEdit EditService()
        {
            return new XpCmsEdit(Ctrl);
        }

        //by dirUpload & cmsType
        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Str.ToJson(json)!, t0_FileName, DirUpload, CmsType));
        }

        //by dirUpload
        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Str.ToJson(json)!, t0_FileName, DirUpload));
        }

        //by cmsType
        public async Task<FileResult?> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewCmsTypeAsync(fid, key, ext, CmsType);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

        /// <summary>
        /// upload html image, image fileName: _Str.NewId() string
        /// </summary>
        /// <param name="file"></param>
        /// <returns>return image url</returns>
        public async Task<string> SetHtmlImage(IFormFile file)
        {
            var subDir = "image/Cms" + CmsType;
            var fileName = await _HttpFile.SaveFileByNewIdA(file, $"{_FunApi.DirWeb}{subDir}");
            return _Fun.GetHtmlImageUrl($"{subDir}/{fileName}");
        }

    }//class
}