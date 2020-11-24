using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jenkins.NETStandard.Core.Domain
{
    public class Job
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

        [JsonPropertyName("buildable")] 
        public bool Buildable { get; set; }

        [JsonPropertyName("builds")] 
        public List<Build> Builds { get; set; }

        [JsonPropertyName("color")] 
        public string Color { get; set; }

        [JsonPropertyName("firstBuild")] 
        public Build FirstBuild { get; set; }

        [JsonPropertyName("healthReport")] 
        public List<HealthReport> HealthReport { get; set; }

        [JsonPropertyName("inQueue")] 
        public bool InQueue { get; set; }

        [JsonPropertyName("lastBuild")] 
        public Build LastBuild { get; set; }

        [JsonPropertyName("lastCompletedBuild")] 
        public Build LastCompleteBuild { get; set; }

        [JsonPropertyName("lastUnstableBuild")] 
        public Build LastUnstableBuild { get; set; }

        [JsonPropertyName("lastUnsuccessfulBuild")] 
        public Build LastUnsuccessfulBuild { get; set; }

        [JsonPropertyName("nextBuildNumber")] 
        public int NextBuildNumber { get; set; }

        [JsonPropertyName("property")] 
        public List<Property> Property { get; set; }
        
    }

    public class Build
    {
        [JsonPropertyName("_class")] 
        public string Clazz { get; set; }

        [JsonPropertyName("number")] 
        public int Number { get; set; }

        [JsonPropertyName("url")] 
        public string Url { get; set; }
    }

    public class HealthReport
    {
        [JsonPropertyName("description")] 
        public string Description { get; set; }

        [JsonPropertyName("score")] 
        public int Score { get; set; }
    }

    public class Property
    {
        [JsonPropertyName("_class")] 
        public string Clazz { get; set; }

        [JsonPropertyName("parameterDefinitions")] 
        public List<ParameterDefinitions> ParameterDefinitions { get; set; }
    }

    public class ParameterDefinitions
    {
        [JsonPropertyName("_class")] 
        public string Clazz { get; set; }

        [JsonPropertyName("defaultParameterValue")] 
        public DefaultParameterValue DefaultParameterValue { get; set; }

        [JsonPropertyName("description")] 
        public string Description { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("type")] 
        public string Type { get; set; }
        
    }

    public class DefaultParameterValue
    {
        [JsonPropertyName("_class")] 
        public string Clazz { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("value")] 
        public string Value { get; set; }
    }
}