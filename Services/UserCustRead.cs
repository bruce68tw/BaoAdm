using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class UserCustRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select *
from dbo.UserCust
order by Id
",
            Items = new QitemDto[] {
                new() { Fid = "Account", Op = ItemOpEstr.Like },
                new() { Fid = "Name", Op = ItemOpEstr.Like },
            },
        };

        public async Task<JObject> GetPage(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

    } //class
}