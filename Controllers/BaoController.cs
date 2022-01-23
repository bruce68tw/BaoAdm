using BaoAdm.Services;
using Base.Models;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class BaoController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new BaoRead().GetPage(Ctrl, dt));
        }

    }//class
}