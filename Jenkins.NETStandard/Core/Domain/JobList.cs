using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jenkins.NETStandard.Core.Domain
{
    public class JobList
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        
        [JsonPropertyName("fullDisplayName")]
        public string FullDisplayName { get; set; }

        [JsonPropertyName("fullName")] 
        public string FullName { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("url")] 
        public string Url { get; set; }
        
        [JsonPropertyName("healthReport")] 
        public List<HealthReport> HealthReport { get; set; }

        [JsonPropertyName("jobs")] 
        public List<SimpleJob> Jobs { get; set; }
    }

    public class SimpleJob
    {
        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("url")] 
        public string Url { get; set; }
        
        [JsonPropertyName("color")] 
        public string Color { get; set; }
    }
}