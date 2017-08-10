using System.IO;
using System.Web;

namespace SimplePublishingPlatform.Extensions
{
    static class RepertoryPathHelper
    {
        private const string RepertoryMapPath = "~/Repertory";
        private const string RepertoryPath = "/Repertory";
        private const string DetailHtmlFileName = "detail.html";


        public static string GetRepertoryNameMapPath(this string repertoryName, HttpServerUtilityBase server)
        {
            return server.MapPath(Path.Combine(RepertoryMapPath, repertoryName));
        }

        public static string GetRepertoryNameUrl(this string repertoryName)
        {
            return RepertoryPath + "/" + repertoryName;
        }

        public static string GetDetailHtmlFilePath(this string repertoryName,HttpServerUtilityBase server)
        {
            var repertoryNamePath=repertoryName.GetRepertoryNameMapPath(server);
            return Path.Combine(repertoryNamePath, DetailHtmlFileName);
        }
    }
}