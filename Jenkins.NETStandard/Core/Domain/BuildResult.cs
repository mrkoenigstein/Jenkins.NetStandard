using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Jenkins.NETStandard.Core.Domain
{
    public class BuildResult
    {
        private static readonly Regex ExpItemNumber = new Regex(@"\/queue\/item\/(\d+)\/*", RegexOptions.Compiled);

        /// <summary>
        /// The URL of the Queue reference item.
        /// </summary>
        public string QueueItemUrl {get; internal set;}

        public int? QueueItemNumber
        {
            get
            {
                var match = ExpItemNumber.Match(QueueItemUrl);
                var matchGroup = match.Groups[1];
                if (matchGroup.Success == false) return null;
                var matchGroupValue = matchGroup.Value;
                int.TryParse(matchGroupValue, out var number);
                return number; 
            }
        }

        internal BuildResult() {}
    }
}