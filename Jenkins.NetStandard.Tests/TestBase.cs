using System;
using Jenkins.NETStandard;

namespace Jenkins.NetStandard.Tests
{
    public class TestBase
    {
        protected readonly Uri Uri = new("http://localhost:8080");

        protected const string Username = "admin";

        protected const string ApiToken = "11ccff2956c3bc649a8ab0e42406973170";

        protected const string JobName = "TestJob";

        protected const string JobNameWithParams = "TestJobWithParams";

        protected const string JobPath = "TestPath";

        protected readonly JenkinsClient JenkinsClient;
        
        public TestBase()
        {
            JenkinsClient = new JenkinsClient(Uri, Username,ApiToken);
        }

       
    }
}