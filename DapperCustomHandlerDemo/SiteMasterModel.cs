using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace DapperCustomHandlerDemo
{
    public class SiteMasterModel
    {
        public int SiteId { get; set; }

        public string SIteName { get; set; }

        public int ClientId { get; set; }

        public SiteConfigurationDictionary SiteConfiguration { get; set; }
    }

    public class SiteConfigurationDictionary : Dictionary<string, string>
    {
        public override string ToString()
        {
            return Join("|", this.Select(item => $"{item.Key}={item.Value}"));
        }

        public static SiteConfigurationDictionary FromConfigurationString(string value)
        {
            //IDictionary<string, string> configDict = new Dictionary<string, string>();
            SiteConfigurationDictionary configDict = new SiteConfigurationDictionary();

            if (string.IsNullOrEmpty(value))
                return configDict;

            var configArray = value.Split('|');

            foreach (var configInfo in configArray)
            {
                var splitedData = configInfo.Split('=');
                if (!configDict.ContainsKey(splitedData[0]))
                {
                    configDict.Add(splitedData[0], splitedData[1]);
                }
            }

            return configDict;
        }
    }
}
