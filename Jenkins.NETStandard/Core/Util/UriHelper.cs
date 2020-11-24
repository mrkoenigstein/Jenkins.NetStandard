using System;
using System.Net;

namespace Jenkins.NETStandard.Core.Util
{
    public class UriHelper
    {
        public static UriBuilder AddQuery(UriBuilder uriBuilder, string name, string value)
        {
            var query = uriBuilder.Query;
            var queryParam = WebUtility.UrlEncode(name) + "=" + WebUtility.UrlEncode(value);
            if(string.IsNullOrEmpty(query))
            {
                uriBuilder.Query = queryParam;
            }
            else
            {
                uriBuilder.Query = query + "&" + queryParam;
            }
            return uriBuilder;
        }
    }
}