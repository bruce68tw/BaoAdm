using BaoLib.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class BaoEdit : XgEdit
    {
        public BaoEdit(string ctrl) : base(ctrl) { }

        private string _key;

        override public EditDto GetDto()
        {
            return new EditDto
            {
                ReadSql = "select * from dbo.Bao where Id='{0}'",
                Table = "dbo.[Bao]",
                PkeyFid = "Id",
                Col4 = new string[] { null, null, null, "Revised" },
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
					new() { Fid = "LaunchStatus", Required = true },
                },
            };
        }

        override public async Task<ResultDto> UpdateAsync(string key, JObject json)
        {
            _key = key;
            return await EditService().UpdateAsync(key, json, fnAfterSave: AfterUpdateAsync);
        }

        private async Task<string> AfterUpdateAsync(Db db, JObject keyJson)
        {
            var key = RedisTypeEstr.BaoDetail + _key;
            await _Redis.DeleteKeyAsync(key);
            return "";
        }

    } //class
}
