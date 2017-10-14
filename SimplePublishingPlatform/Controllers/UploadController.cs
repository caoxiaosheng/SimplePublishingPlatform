using System;
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
            var repertoryNamePath = repertoryName.GetRepertoryNameMapPath(Server);
            //获取图片文件名
            var fileName = Path.GetFileName(upload.FileName);
            if (string.IsNullOrEmpty(fileName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filePhysicalPath = Path.Combine(repertoryNamePath, fileName);
            upload.SaveAs(filePhysicalPath); //上传图片到指定文件夹
            var url = repertoryName.GetRepertoryNameUrl() + "/" + fileName;
            var ckEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum + ", \"" + url +
                           "\");</script>");
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var repertoryName = Request["repertoryName"];
            var secondDir = Request["secondDir"];
            var repertoryNamePath = repertoryName.GetRepertoryNameMapPath(Server);
            var files = Request.Files;
            if (files == null)
            {
                return Json(new { error = "上传文件列表为空" });
            }
            if (files.Count != 1)
            {
                return Json(new { error = "存在" + files.Count + "个文件" });
            }
            var fileName = files[0]?.FileName;
            if (string.IsNullOrEmpty(fileName))
            {
                return Json(new { error = "文件名为空" });
            }
            var dirPath = Path.Combine(repertoryNamePath, secondDir);
            if (Directory.Exists(dirPath) == false)
            {
                Directory.CreateDirectory(dirPath);
            }
            //string type = fileName.Substring(fileName.LastIndexOf('.'));
            //fileName = secondDir + type;
            var filePhysicalPath = Path.Combine(repertoryNamePath, secondDir, fileName);
            files[0].SaveAs(filePhysicalPath); //上传图片到指定文件夹
            return Json(new {});
        }
    }
}