using System.IO;
using System.Net;
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filePhysicalPath = Path.Combine(repertoryNamePath, fileName);
            upload.SaveAs(filePhysicalPath); //上传图片到指定文件夹
            var url = "/" + fileName;
            var ckEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum + ", \"" + url +
                           "\");</script>");

        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var repertoryName = Request["repertoryName"];
            var repertoryNamePath = Server.MapPath(repertoryName.GetRepertoryNamePath());
            var files = Request.Files;
            if (files.Count != 1)
            {
                return Json(new { success = false, reason = "存在" + files.Count + "个文件" });
            }
            var fileName = files[0].FileName;
            if (string.IsNullOrEmpty(fileName))
            {
                return Json(new { success = false, reason = "文件名为空" });
            }
            var filePhysicalPath = Path.Combine(repertoryNamePath, fileName);
            files[0].SaveAs(filePhysicalPath); //上传图片到指定文件夹
            return Json(new { success = true, filename= fileName });
        }
    }
}