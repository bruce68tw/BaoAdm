using Base.Models;
using BaseApi.Controllers;
using BaoAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BaseWeb.Attributes;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class UserCustController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserCustRead().GetPage(Ctrl, dt));
        }

        private UserCustEdit EditService()
        {
            return new UserCustEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

    }//class
}