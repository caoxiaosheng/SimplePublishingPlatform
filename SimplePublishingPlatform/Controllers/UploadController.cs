using System.IO;
using System.Web;
using System.Web.Mvc;
using SimplePublishingPlatform.Extensions;

namespace SimplePublishingPlatform.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            var repertoryName= Request["repertoryName"];
            var repertoryNamePath = Server.MapPath(repertoryName.GetRepertoryNamePath());
            //获取图片文件名
            var fileName = Path.GetFileName(upload.FileName);
            if (string.IsNullOrEmpty(fileName))
            {
                return new HttpNotFoundResult();
            }
            var filePhysicalPath = Path.Combine(repertoryNamePath, fileName);
            upload.SaveAs(filePhysicalPath); //上传图片到指定文件夹
            var url = "/" + fileName;
            var ckEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum + ", \"" + url +
                           "\");</script>");

        }
    }
}