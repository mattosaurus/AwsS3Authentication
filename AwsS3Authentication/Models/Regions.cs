using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AwsS3Authentication.Models
{
    public static class Regions
    {
        private static readonly Regex endpointRegex = new Regex(@"s3[.\-](.*?)\.amazonaws\.com$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.RightToLeft);
        private static readonly ConcurrentDictionary<string, string> cache = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Get corresponding region for input host.
        /// </summary>
        /// <param name="endpoint">S3 API endpoint</param>
        /// <returns>Region corresponding to the endpoint. Default is 'us-east-1'</returns>
        public static string GetRegionFromEndpoint(string endpoint)
        {
            return cache.GetOrAdd(endpoint, GetRegionFromEndpointImpl);
        }

        private static string GetRegionFromEndpointImpl(string endpoint)
        {
            Match match = endpointRegex.Match(endpoint);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return string.Empty;
        }
    }
}
