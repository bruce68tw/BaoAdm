using BaoLib.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class BaoEdit : BaseEditSvc
    {
        public BaoEdit(string ctrl) : base(ctrl) { }

        private string _userId = "";
        private string _key = "" ;

        override public EditDto GetDto()
        {
            return new EditDto
            {
                ReadSql = "select * from dbo.Bao where Id=@Id",
                Table = "dbo.[Bao]",
                PkeyFid = "Id",
                Col4 = new string[] { "", "", "", "Revised" },
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
					new() { Fid = "LaunchStatus", Required = true },
                },
            };
        }

        override public async Task<ResultDto> UpdateA(string key, JObject json)
        {
            _key = key;
            _userId = _Fun.UserId();
            return await EditService().UpdateA(key, json, fnAfterSaveA: AfterUpdateA);
        }

        private async Task<string> AfterUpdateA(CrudEditSvc editService, Db db, JObject keyJson)
        {
            var key = RedisTypeEstr.BaoDetail + _key;
            _Cache.DeleteKey(_userId, key);
            return "";
        }

    } //class
}
