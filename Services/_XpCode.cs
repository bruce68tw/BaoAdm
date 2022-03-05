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
        public static async Task<List<IdStrDto>> GetProjectsAsync(Db db = null)
        {
            return await TableToListAsync("Project", db);
        }
        public static async Task<List<IdStrDto>> GetUsersAsync(Db db = null)
        {
            return await TableToListAsync("User", db);
        }
        public static async Task<List<IdStrDto>> GetDeptsAsync(Db db = null)
        {
            return await TableToListAsync("Dept", db);
        }
        public static async Task<List<IdStrDto>> GetRolesAsync(Db db = null)
        {
            return await TableToListAsync("XpRole", db);
        }
        public static async Task<List<IdStrDto>> GetProgsAsync(Db db = null)
        {
            //return TableToList("XpProg", db);
            var sql = @"
select 
    Id, (case when AuthRow=1 then '*' else '' end)+Name as Str
from dbo.XpProg
order by Id";
            return await SqlToListAsync(sql, db);
        }
        public static async Task<List<IdStrDto>> GetFlowsAsync(Db db = null)
        {
            return await TableToListAsync("XpFlow", db);
        }
        #endregion

        #region get from XpCode table
        public static async Task<List<IdStrDto>> GetLaunchStatusesAsync(Db db = null)
        {
            return await TypeToListAsync("LaunchStatus", db);
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

        private static async Task<List<IdStrDto>> TableToListAsync(string table, Db db = null)
        {
            var sql = string.Format(@"
select 
    Id, Name as Str
from dbo.[{0}]
order by Id
", table);
            return await SqlToListAsync(sql, db);
        }

        //get codes from sql 
        private static async Task<List<IdStrDto>> SqlToListAsync(string sql, Db db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsAsync<IdStrDto>(sql);
            await _Fun.CheckCloseDb(db, emptyDb);
            return rows;
        }

        //get code table rows
        private static async Task<List<IdStrDto>> TypeToListAsync(string type, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return await SqlToListAsync(sql, db);
        }

    }//class
}
