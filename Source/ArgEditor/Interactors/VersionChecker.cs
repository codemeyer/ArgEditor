using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ArgEditor.Interactors
{
    public class VersionChecker
    {
        public string GetLatestVersion()
        {
            var webClient = new WebClient();
            try
            {
                byte[] latestVersionData = webClient.DownloadData("http://www.argtools.com/downloads/argeditor/latest-version.json");
                string latestVersionText = Encoding.UTF8.GetString(latestVersionData);
                var latestVersion = JsonConvert.DeserializeObject<LatestVersionClass>(latestVersionText);

                return latestVersion.LatestVersion;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public bool Compare(string thisVersion, string latestVersion)
        {
            string[] thisParts = thisVersion.Split('.');
            long thisNumber = Convert.ToInt64(VersionNumber(thisParts));

            string[] latestParts = latestVersion.Split('.');
            long latestNumber = Convert.ToInt64(VersionNumber(latestParts));

            return (latestNumber > thisNumber);
        }

        private string VersionNumber(string[] v)
        {
            return v[0] + v[1].PadLeft(5, '0') + v[2].PadLeft(5, '0') + v[3].PadLeft(5, '0');
        }
    }

    public class LatestVersionClass
    {
        [JsonProperty("latest-version")]
        public string LatestVersion { get; set; }
    }
}
