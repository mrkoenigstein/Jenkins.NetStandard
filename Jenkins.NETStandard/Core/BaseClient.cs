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
    }
}