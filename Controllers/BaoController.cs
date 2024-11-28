using BaoAdm.Services;
using BaoLib.Services;
using Base.Models;
using Base.Services;
using BaseApi.Attributes;
using BaseApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class BaoController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            await using (var db = new Db()) {
                ViewBag.LaunchStatuses = await _XpLibCode.LaunchStatusesA(db);
                ViewBag.ReplyTypes = await _XpLibCode.ReplyTypesA(db);
                ViewBag.PrizeTypes = await _XpLibCode.PrizeTypesA(db);
            }
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
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)!));
        }

    }//class
}