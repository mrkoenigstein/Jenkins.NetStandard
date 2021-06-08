using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Jenkins.NETStandard.Core;

namespace Jenkins.NETStandard
{
    public class JenkinsClient
    {
        internal HttpClient Client { get;}
        public Uri BaseUri { get; set; }
        public string Username { get; set; }
        
        private JobsClient _jobsClient;

        private BuildClient _buildClient;
        
        private QueueClient _queueClient;

        public JenkinsClient(Uri baseUrl, string userName, string apiToken)
        {
            BaseUri = baseUrl;
            Username = userName;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
            Client = new HttpClient();
            var bytes = Encoding.ASCII.GetBytes(userName + ":" + apiToken);
            var base64Token = Convert.ToBase64String(bytes);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Token);
        }
        
        public JobsClient JobsClient => _jobsClient ??= new JobsClient(this);
        public BuildClient BuildClient => _buildClient ??= new BuildClient(this);

        public QueueClient QueueClient => _queueClient ??= new QueueClient(this);
    }
}