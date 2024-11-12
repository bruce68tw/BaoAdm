using BaoAdm.Services;
using Base.Models;
using BaseApi.Attributes;
using BaseApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class UserAppController : BaseCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserAppRead().GetPage(Ctrl, dt));
        }

        private UserAppEdit EditService()
        {
            return new UserAppEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

    }//class
}