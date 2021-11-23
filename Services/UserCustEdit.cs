using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace BaoAdm.Services
{
    public class UserCustEdit : XpEdit
    {
        public UserCustEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[UserCust]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
                    new() { Fid = "Account" },
                    new() { Fid = "Name" },
					new() { Fid = "Phone" },
					new() { Fid = "Email" },
					new() { Fid = "IsCorp" },
					new() { Fid = "Created" },
                },
            };
        }

    } //class
}
