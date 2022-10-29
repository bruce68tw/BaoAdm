using Base.Models;
using Base.Services;

namespace BaoAdm.Services
{
    public class UserCustEdit : XgEdit
    {
        public UserCustEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[UserCust]",
                PkeyFid = "Id",
                Col4 = new[] { null, "Created" },
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
                    new() { Fid = "Account" },
                    new() { Fid = "Name" },
					new() { Fid = "Phone" },
					new() { Fid = "Email" },
                    new() { Fid = "Status" },
                    new() { Fid = "IsCorp" },
                    new() { Fid = "Address" },
                    new() { Fid = "Created" },
                },
            };
        }

    } //class
}
