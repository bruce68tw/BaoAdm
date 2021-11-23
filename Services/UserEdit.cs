﻿using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace BaoAdm.Services
{
    public class UserEdit : XpEdit
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