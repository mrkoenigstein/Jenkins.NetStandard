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
            var build = JenkinsClient.BuildClient.Build(JobPath, JobName);
            build.Should().NotBeNull();
            build.QueueItemNumber.Should().NotBeNull();
        }

        [TestMethod]
        public void TestBuildWithParameters()
        {
            var parameter = new Dictionary<string, string>
            {
                { "A", "foo" },
                { "B", "bar" },
                { "C", "true" }
            };
            var buildWithParameter = JenkinsClient.BuildClient.BuildWithParameter(JobPath,JobNameWithParams, parameter);
            buildWithParameter.Should().NotBeNull();
            buildWithParameter.QueueItemNumber.Should().NotBeNull();
        }


        [TestMethod]
        public void TestGetQueueInfo()
        {
            var build = JenkinsClient.BuildClient.Build(JobPath,JobName);
            build.Should().NotBeNull();
            build.QueueItemNumber.Should().NotBeNull();
            var queueItemInfo = JenkinsClient.QueueClient.GetQueueItemInfo(build.QueueItemNumber);
            queueItemInfo.Should().NotBeNull();
        }
    }
}