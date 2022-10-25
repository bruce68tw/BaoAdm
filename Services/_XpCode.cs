//using BaoAdm.Tables;
using Base.Models;
using Base.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaoAdm.Services
{
    //for dropdown input
    public static class _XpCode
    {
        #region master table to codes
        public static async Task<List<IdStrDto>> GetProjectsA(Db db = null)
        {
            return await TableToListA("Project", db);
        }
        public static async Task<List<IdStrDto>> GetUsersA(Db db = null)
        {
            return await TableToListA("User", db);
        }
        public static async Task<List<IdStrDto>> GetDeptsA(Db db = null)
        {
            return await TableToListA("Dept", db);
        }
        public static async Task<List<IdStrDto>> GetRolesA(Db db = null)
        {
            return await TableToListA("XpRole", db);
        }
        public static async Task<List<IdStrDto>> GetProgsA(Db db = null)
        {
            //return TableToList("XpProg", db);
            var sql = @"
select 
    Id, (case when AuthRow=1 then '*' else '' end)+Name as Str
from dbo.XpProg
order by Id";
            return await _Db.SqlToCodesA(sql, db);
        }
        public static async Task<List<IdStrDto>> GetFlowsA(Db db = null)
        {
            return await TableToListA("XpFlow", db);
        }
        #endregion

        #region get from XpCode table
        public static async Task<List<IdStrDto>> GetLaunchStatusesA(Db db = null)
        {
            return await TypeToListA("LaunchStatus", db);
        }
        #endregion

        #region others
        public static List<IdStrDto> GetSelects()
        {
            return new List<IdStrDto>(){
                new IdStrDto(){ Id="1", Str="Select1"},
                new IdStrDto(){ Id="2", Str="Select2"},
            };
        }
        public static List<IdStrDto> GetRadios()
        {
            return new List<IdStrDto>(){
                new IdStrDto(){ Id="1", Str="Radio1"},
                new IdStrDto(){ Id="2", Str="Radio2"},
            };
        }
        #endregion

        private static async Task<List<IdStrDto>> TableToListA(string table, Db db = null)
        {
            var sql = string.Format(@"
select 
    Id, Name as Str
from dbo.[{0}]
order by Id
", table);
            return await _Db.SqlToCodesA(sql, db);
        }

        /*
        //get codes from sql 
        private static async Task<List<IdStrDto>> SqlToListAsync(string sql, Db db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsA<IdStrDto>(sql);
            await _Fun.CheckCloseDbA(db, emptyDb);
            return rows;
        }
        */

        //get code table rows
        private static async Task<List<IdStrDto>> TypeToListA(string type, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return await _Db.SqlToCodesA(sql, db);
        }

    }//class
}
