using System.Text.Json;
using Jenkins.NETStandard.Core.Domain;

namespace Jenkins.NETStandard.Core
{
    public class QueueClient : BaseClient
    {
        public QueueClient(JenkinsClient jenkinsClient) : base(jenkinsClient)
        {
        }
        
        public QueueItemInfo GetQueueItemInfo(int? itemNumber)
        {
            var url = $"{BaseUri}/queue/item/{itemNumber}/api/json?pretty=true";
            var stream = Client.GetStringAsync(url);
            var streamResult = stream.Result;
            return JsonSerializer.Deserialize<QueueItemInfo>(streamResult);
        }
    }
}