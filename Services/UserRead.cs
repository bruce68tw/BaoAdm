using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class UserRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select * from dbo.[User]
order by Id
",
            Items = new QitemDto[] {
                new() { Fid = "Name", Op = ItemOpEstr.Like },
                new() { Fid = "Account", Op = ItemOpEstr.Like },
            },
        };

        public async Task<JObject> GetPage(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageA(dto, dt, ctrl);
        }

    } //class
}