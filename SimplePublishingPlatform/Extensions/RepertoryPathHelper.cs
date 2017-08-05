using System.IO;

namespace SimplePublishingPlatform.Extensions
{
    static class RepertoryPathHelper
    {
        private const string RepertoryPath = "~/Repertory";

        public static string GetRepertoryNamePath(this string repertoryName)
        {
            return Path.Combine(RepertoryPath, repertoryName);
        }
    }
}