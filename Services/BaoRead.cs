using BaoLib.Enums;
using BaoLib.Services;
using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class BaoRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = $@"
select b.*, 
    AnswerTypeName=x.Name,
    PrizeTypeName=x2.Name,
    Corp=c.Name
from dbo.Bao b
join dbo.UserCust c on b.Creator=c.Id
join dbo.XpCode x on x.Type='{_XpLib.AnswerType}' and b.AnswerType=x.Value
join dbo.XpCode x2 on x2.Type='{_XpLib.PrizeType}' and b.PrizeType=x2.Value
order by b.StartTime desc
",
            Items = [
                new QitemDto { Fid = "Name", Op = ItemOpEstr.Like },
            ],
        };

        public async Task<JObject?> GetPage(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(dto, dt, ctrl);
        }

    } //class
}