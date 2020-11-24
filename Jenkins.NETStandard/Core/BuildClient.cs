using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Jenkins.NETStandard.Core.Domain;
using Jenkins.NETStandard.Core.Util;

namespace Jenkins.NETStandard.Core
{
    public class BuildClient : BaseClient
    {
        public BuildClient(JenkinsClient jenkinsClient) : base(jenkinsClient)
        {
        }

        public BuildResult Build(string jobName)
        {
            var url = $"{BaseUri}job/{jobName}/build";
            var response = Client.PostAsync(url, new MultipartFormDataContent());
            var responseMessage = response.Result;
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.Created:
                {
                    var headersLocation = responseMessage.Headers.Location;
                    return new BuildResult
                    {
                        QueueItemUrl = headersLocation.ToString()
                    };
                }
                default:
                    Trace.WriteLine($"{responseMessage.StatusCode}:{responseMessage.ReasonPhrase}");
                    return null;
            }
        }

        public BuildResult BuildWithParameter(string jobName, IDictionary<string, string> jobParameters)
        {
            var uriBuilder = new UriBuilder($"{BaseUri}job/{jobName}/buildWithParameters");
            foreach (var (key, value) in jobParameters)
            {
                uriBuilder = UriHelper.AddQuery(uriBuilder, key, value);
            }
            var response = Client.PostAsync(uriBuilder.ToString(), new MultipartFormDataContent());
            var responseMessage = response.Result;
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.Created:
                {
                    var headersLocation = responseMessage.Headers.Location;
                    return new BuildResult
                    {
                        QueueItemUrl = headersLocation.ToString()
                    };
                }
                default:
                    Trace.WriteLine($"{responseMessage.StatusCode}:{responseMessage.ReasonPhrase}");
                    return null;
            }
            
        }
    }
}