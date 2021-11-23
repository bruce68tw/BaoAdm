using BaoAdm.Enums;
using BaoAdm.Models;
using BaseWeb.Attributes;

namespace BaoAdm.Controllers
{
    [XgLogin]
    public class CmsCardController : XpCmsController
    {
        public CmsCardController()
        {
            CmsType = CmsTypeEstr.Card;
            //DirUpload = _Xp.DirCmsType(CmsType);
            EditDto = new CmsEditDto()
            {
                Title = "標題",
                //Text = "內容",
                Html = "賀卡內容",
                //Note = "備註",
                //FileName = "上傳檔案",
                StartTime = "發佈時間",
                EndTime = "結束時間",
            };
        }

    }//class
}