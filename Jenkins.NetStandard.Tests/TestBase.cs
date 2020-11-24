using System;
using Jenkins.NETStandard;

namespace Jenkins.NetStandard.Tests
{
    public class TestBase
    {
        protected readonly Uri Uri = new Uri("https://localhost:8080");

        protected const string Username = "admin";

        protected const string ApiToken = "";
        
        public readonly string JobName = "/job/TestJob";

        public readonly string JobPath = "TestPath";

        protected readonly JenkinsClient JenkinsClient;
        
        public TestBase()
        {
            JenkinsClient = new JenkinsClient(Uri, Username,ApiToken);
        }

       
    }
}