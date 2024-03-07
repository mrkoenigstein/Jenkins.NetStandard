using System;
using System.Net.Http;

namespace Jenkins.NETStandard.Core
{
    public class BaseClient
    {
        private JenkinsClient _jenkinsClient;

        private readonly string _username;

        protected readonly Uri BaseUri;

        protected readonly HttpClient Client;

        protected BaseClient(JenkinsClient jenkinsClient)
        {
            _jenkinsClient = jenkinsClient;
            Client = jenkinsClient.Client;
            BaseUri = jenkinsClient.BaseUri;
            _username = jenkinsClient.Username;
        }

        protected string CreateJobPath(string jobPath, string jobName)
        {
            var url = $"job/{jobName}";
            if (string.IsNullOrEmpty(jobPath) == false)
            {
                // If the JobPath contains more then one folder replace it with the need job string
                jobPath = jobPath.Replace("/", "/job/");
                url = $"job/{jobPath}/{url}";
            }
            return $"{BaseUri}{url}";
        }
    }
}