using System.Text.Json;
using Jenkins.NETStandard.Core.Domain;

namespace Jenkins.NETStandard.Core
{
    public class JobsClient : BaseClient
    {
        public JobsClient(JenkinsClient jenkinsClient) : base(jenkinsClient)
        {
        }

        public Job Job(string jobName)
        {
            var url = $"{BaseUri}/job/{jobName}/api/json";
            var stream = Client.GetStringAsync(url);
            var streamResult = stream.Result;
            return JsonSerializer.Deserialize<Job>(streamResult);
        }

        public JobList JobList(string path)
        {
            var url = $"{BaseUri}/job/{path}/api/json";
            var stream = Client.GetStringAsync(url);
            var streamResult = stream.Result;
            return JsonSerializer.Deserialize<JobList>(streamResult);
        }
    }
}