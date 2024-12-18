﻿using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class UserAppRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select *
from dbo.UserApp
order by Id
",
            Items = new QitemDto[] {
                new() { Fid = "Name", Op = ItemOpEstr.Like },
                new() { Fid = "Phone", Op = ItemOpEstr.Like },
            },
        };

        public async Task<JObject?> GetPage(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(dto, dt, ctrl);
        }

    } //class
}