using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jenkins.NetStandard.Tests
{
    [TestClass]
    public class TestJenkinsJobClient : TestBase
    {
        [TestMethod]
        public void TestGetJob()
        {
            var jenkinsJob = JenkinsClient.JobsClient.Job(JobName);
            jenkinsJob.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetJobList()
        {
            var jobList = JenkinsClient.JobsClient.JobList(JobPath);
            jobList.Should().NotBeNull();
        }

        [TestMethod]
        public void TestBuild()
        {
            var build = JenkinsClient.BuildClient.Build(JobName);
            build.Should().NotBeNull();
            build.QueueItemNumber.Should().NotBeNull();
        }

        [TestMethod]
        public void TestBuildWithParameters()
        {
            var parameter = new Dictionary<string, string> {{"param", "test"}};
            var buildWithParameter = JenkinsClient.BuildClient.BuildWithParameter(JobName, parameter);
            buildWithParameter.Should().NotBeNull();
            buildWithParameter.QueueItemNumber.Should().NotBeNull();
        }
    }
}