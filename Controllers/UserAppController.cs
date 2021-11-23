using Base.Models;
using BaseApi.Controllers;
using BaoAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BaseWeb.Attributes;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class UserAppController : ApiCtrl
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
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

    }//class
}