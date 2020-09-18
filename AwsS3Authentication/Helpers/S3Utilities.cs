﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AwsS3Authentication.Helpers
{
    internal class S3Utilities
    {
        internal static readonly Regex TrimWhitespaceRegex = new Regex("\\s+");

        internal static bool IsAmazonEndPoint(string endpoint)
        {
            if (IsAmazonChinaEndPoint(endpoint))
            {
                return true;
            }
            Regex rgx = new Regex("^s3[.-]?(.*?)\\.amazonaws\\.com$", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(endpoint);
            return matches.Count > 0;
        }

        // IsAmazonChinaEndpoint - Match if it is exactly Amazon S3 China endpoint.
        // Customers who wish to use the new Beijing Region are required
        // to sign up for a separate set of account credentials unique to
        // the China (Beijing) Region. Customers with existing AWS credentials
        // will not be able to access resources in the new Region, and vice versa.
        // For more info https://aws.amazon.com/about-aws/whats-new/2013/12/18/announcing-the-aws-china-beijing-region/
        internal static bool IsAmazonChinaEndPoint(string endpoint)
        {
            return endpoint == "s3.cn-north-1.amazonaws.com.cn";
        }

        // IsVirtualHostSupported - verifies if bucketName can be part of
        // virtual host. Currently only Amazon S3 and Google Cloud Storage
        // would support this.
        internal static bool IsVirtualHostSupported(Uri endpointURL, string bucketName)
        {
            if (endpointURL == null)
            {
                return false;
            }
            // bucketName can be valid but '.' in the hostname will fail SSL
            // certificate validation. So do not use host-style for such buckets.
            if (endpointURL.Scheme == "https" && bucketName.Contains("."))
            {
                return false;
            }
            // Return true for all other cases
            return IsAmazonEndPoint(endpointURL.Host);
        }

        internal static string GetPath(string p1, string p2)
        {
            try
            {
                string combination = Path.Combine(p1, p2);
                combination = Uri.EscapeUriString(combination);
                return combination;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// IsValidIP parses input string for ip address validity.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        internal static bool IsValidIP(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                return false;
            }

            string[] splitValues = ip.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out var _));
        }

        // TrimAll trims leading and trailing spaces and replace sequential spaces with one space, following Trimall()
        // in http://docs.aws.amazon.com/general/latest/gr/sigv4-create-canonical-request.html
        internal static string TrimAll(string s)
        {
            return TrimWhitespaceRegex.Replace(s, " ").Trim();
        }
    }
}