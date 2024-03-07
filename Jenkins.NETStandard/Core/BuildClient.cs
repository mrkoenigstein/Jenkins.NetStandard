using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Jenkins.NETStandard.Core.Domain;
using Jenkins.NETStandard.Core.Util;

namespace Jenkins.NETStandard.Core;

public class BuildClient : BaseClient
{
    public BuildClient(JenkinsClient jenkinsClient) : base(jenkinsClient)
    {
    }

    /// <summary>
    /// Start a Build for a given JobName and JobPath
    /// </summary>
    /// <param name="jobPath">The Folder Path to the Job. Example: Folder/Subfolder/Subfolder </param>
    /// <param name="jobName">The Name of the Job</param>
    /// <returns>A BuildResult</returns>
    public BuildResult Build(string jobPath, string jobName)
    {
        var path = CreateJobPath(jobPath, jobName);
        var url = $"{path}/build";
        var response = Client.PostAsync(url, new MultipartFormDataContent());
        var responseMessage = response.Result;
        switch (responseMessage.StatusCode)
        {
            case HttpStatusCode.Created:
            {
                var headersLocation = responseMessage.Headers.Location;
                return new BuildResult
                {
                    QueueItemUrl = headersLocation.ToString()
                };
            }
            default:
                Trace.WriteLine($"{responseMessage.StatusCode}:{responseMessage.ReasonPhrase}");
                return null;
        }
    }

    /// <summary>
    /// Start a Build with Parameters for a given JobName and JobPath
    /// </summary>
    /// <param name="jobPath">The Folder Path to the Job. Example: Folder/Subfolder/Subfolder </param>
    /// <param name="jobName">The Name of the Job</param>
    /// <param name="parameters">Dictionary of Parameter</param>
    /// <returns>A BuildResult</returns>
    public BuildResult BuildWithParameter(string jobPath, string jobName, IDictionary<string, string> parameters)
    {
        var path = CreateJobPath(jobPath, jobName);
        var url = $"{path}/buildWithParameters";
        var uriBuilder = new UriBuilder(url);
        foreach (var (key, value) in parameters)
        {
            uriBuilder = UriHelper.AddQuery(uriBuilder, key, value);
        }

        var response = Client.PostAsync(uriBuilder.ToString(), new MultipartFormDataContent());
        var responseMessage = response.Result;
        switch (responseMessage.StatusCode)
        {
            case HttpStatusCode.Created:
            {
                var headersLocation = responseMessage.Headers.Location;
                return new BuildResult
                {
                    QueueItemUrl = headersLocation.ToString()
                };
            }
            default:
                Trace.WriteLine($"{responseMessage.StatusCode}:{responseMessage.ReasonPhrase}");
                return null;
        }
    }
}