using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace DapperCustomHandlerDemo
{
    public class SiteConfigurationHandler : SqlMapper.TypeHandler<SiteConfigurationDictionary>
    {
        public override void SetValue(IDbDataParameter parameter, SiteConfigurationDictionary value)
        {
            parameter.Value = value.ToString();
        }

        public override SiteConfigurationDictionary Parse(object value)
        {
            return SiteConfigurationDictionary.FromConfigurationString(value.ToString());
        }
    }
}
