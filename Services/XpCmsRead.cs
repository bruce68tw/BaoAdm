﻿using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    public class XpCmsRead
    {
        private readonly string _cmsType;

        //constructor
        public XpCmsRead(string cmsType)
        {
            _cmsType = cmsType;
        }

        private ReadDto GetDto()
        {
            return new ReadDto()
            {
                ReadSql = $@"
select *
from dbo.Cms
where CmsType='{_cmsType}'
order by Id desc
",
                Items = new QitemDto[] {
                    new() { Fid = "Title", Op = ItemOpEstr.Like },
                },
            };
        }

        public async Task<JObject?> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(GetDto(), dt, ctrl);
        }

    } //class
}