using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Services;
using BaoAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BaseWeb.Attributes;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class UserController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserRead().GetPage(Ctrl, dt));
        }

        private UserEdit EditService()
        {
            return new UserEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }


        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

    }//class
}