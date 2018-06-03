using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using Dapper;
using static System.Console;

namespace DapperCustomHandlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // First we need to register our custom type handler
            SqlMapper.AddTypeHandler(new SiteConfigurationHandler());

            List<SiteMasterModel> siteList = GetSiteMasterList();
            foreach (var siteInfo in siteList)
            {
                WriteLine($"SiteId: {siteInfo.SiteId}");
                WriteLine($"SIteName: {siteInfo.SIteName}");
                WriteLine("Configuration:");
                foreach (var configItem in siteInfo.SiteConfiguration)
                {
                    WriteLine($"{configItem.Key.PadLeft(28)}: {configItem.Value}");
                }
                WriteLine("==============");
            }
            WriteLine("====  Press any key to exit ===");
            ReadLine();
        }

        private static List<SiteMasterModel> GetSiteMasterList()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["NorthwndConnectionString"].ConnectionString;

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    return conn.Query<SiteMasterModel>
                        (
                            "SELECT SiteId, SIteName, ClientId, SiteConfiguration FROM dbo.WebSiteMaster" 
                         ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
