using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SimplePublishingPlatform.Extensions;

namespace SimplePublishingPlatform.Controllers
{
    public class DownloadController:Controller
    {
        public ActionResult DownLoadSheet(string versionName)
        {
            var repertoryNamePath = versionName.GetRepertoryNameMapPath(Server);
            var sheetPath = Path.Combine(repertoryNamePath, "使用手册");
            var files = Directory.GetFiles(sheetPath);
            if (files.Length != 1)
            {
                return HttpNotFound();
            }
            return File(files[0], "text/plain", Path.GetFileName(files[0]));
        }

        public void DownLoadPackage(string versionName)
        {
            var repertoryNamePath = versionName.GetRepertoryNameMapPath(Server);
            var sheetPath = Path.Combine(repertoryNamePath, "安装包");
            var files = Directory.GetFiles(sheetPath);
            if (files.Length != 1)
            {
                Response.Write("文件错误");
                return;
            }
            string fileName = Path.GetFileName(files[0]);
            string filePath = files[0];
            if (System.IO.File.Exists(filePath))
            {
                const long maxSize = 102400; //100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
                byte[] buffer = new byte[maxSize];
                Response.Clear();
                FileStream iStream;
                using (iStream = System.IO.File.OpenRead(filePath))
                {
                    long dataLengthToRead = iStream.Length; //获取下载的文件总大小
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition",
                        "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                    while (dataLengthToRead > 0 && Response.IsClientConnected)
                    {
                        int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(maxSize)); //读取的大小
                        Response.OutputStream.Write(buffer, 0, lengthRead);
                        Response.Flush();
                        dataLengthToRead = dataLengthToRead - lengthRead;
                    }
                    Response.Close();
                }
            }
        }
    }
}