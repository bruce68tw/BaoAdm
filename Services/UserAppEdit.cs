using Base.Models;
using Base.Services;

namespace BaoAdm.Services
{
    public class UserAppEdit : XgEdit
    {
        public UserAppEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[UserApp]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
					new() { Fid = "Name" },
					new() { Fid = "Phone" },
					new() { Fid = "Email" },
					new() { Fid = "Address" },
					new() { Fid = "Created" },
					new() { Fid = "Revised" },
                },
            };
        }

    } //class
}
