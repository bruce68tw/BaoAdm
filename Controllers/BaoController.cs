using BaoAdm.Services;
using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class BaoController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            ViewBag.LaunchStatuses = await _XpCode.GetLaunchStatusesA();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new BaoRead().GetPage(Ctrl, dt));
        }

        private BaoEdit EditService()
        {
            return new BaoEdit(Ctrl);
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

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)));
        }

    }//class
}