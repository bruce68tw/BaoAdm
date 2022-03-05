using BaoAdm.Models;
using BaoLib.Enums;
using BaseWeb.Attributes;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class CmsMsgController : XpCmsController
    {
        public CmsMsgController()
        {
            CmsType = CmsTypeEstr.Msg;
            //DirUpload = _Xp.DirCmsType(CmsType);
            EditDto = new CmsEditDto()
            {
                Title = "標題",
                Text = "內容",
                //Html = "Html",
                //Note = "備註",
                //FileName = "上傳檔案",
                StartTime = "發佈時間",
                EndTime = "結束時間",
            };
        }

    }//class
}