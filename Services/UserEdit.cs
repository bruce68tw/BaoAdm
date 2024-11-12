using Base.Models;
using Base.Services;

namespace BaoAdm.Services
{
    public class UserEdit : BaseEditSvc
    {
        public UserEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[User]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
					new() { Fid = "Name" },
					new() { Fid = "Account" },
					new() { Fid = "Status" },
					new() { Fid = "IsAdmin" },
                },
            };
        }

    } //class
}
