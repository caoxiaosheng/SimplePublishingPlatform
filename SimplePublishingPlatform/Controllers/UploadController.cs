using System.Web;
using System.Web.Mvc;

namespace SimplePublishingPlatform.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            //获取图片文件名
            var fileName = System.IO.Path.GetFileName(upload.FileName);
            var filePhysicalPath = Server.MapPath("~/"); //我把它保存在网站根目录的 upload 文件夹，需要在项目中添加对应的文件夹
            filePhysicalPath = filePhysicalPath + fileName;
            upload.SaveAs(filePhysicalPath); //上传图片到指定文件夹
            var url = "/" + fileName;
            var ckEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum + ", \"" + url +
                           "\");</script>");

        }
    }
}