using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Models
{
    internal static class Constants
    {
        /// <summary>
        /// Maximum number of parts
        /// </summary>
        public static int MaxParts = 10000;

        /// <summary>
        /// Minimum part size
        /// </summary>
        public static long MinimumPartSize = 5 * 1024L * 1024L;

        /// <summary>
        /// Maximum part size
        /// </summary>
        public static long MaximumPartSize = 5 * 1024L * 1024L * 1024L;

        /// <summary>
        /// Maximum streaming object size
        /// </summary>
        public static long MaximumStreamObjectSize = MaxParts * MinimumPartSize;

        /// <summary>
        /// maxSinglePutObjectSize - maximum size 5GiB of object per PUT operation
        /// </summary>
        public static long MaxSinglePutObjectSize = 1024L * 1024L * 1024L * 5;

        /// <summary>
        /// maxSingleCopyObjectSize - 5GiB
        /// </summary>
        public static long MaxSingleCopyObjectSize = 1024L * 1024L * 1024L * 5;

        /// <summary>
        /// maxMultipartPutObjectSize - maximum size 5TiB of object for Multipart operation
        /// </summary>
        public static long MaxMultipartPutObjectSize = 1024L * 1024L * 1024L * 1024L * 5;

        /// <summary>
        /// OptimalReadBufferSize - optimal buffer 5MiB used for reading through Read operation
        /// </summary>
        public static long OptimalReadBufferSize = 1024L * 1024L * 5;

        public static int DefaultExpiryTime = 7 * 24 * 3600;

        /// <summary>
        /// SSEGenericHeader is the AWS SSE header used for SSE-S3 and SSE-KMS.
        /// </summary>
        public static string SSEGenericHeader = "X-Amz-Server-Side-Encryption";

        /// <summary>
        /// SSEKMSKeyId is the AWS SSE KMS Key-Id
        /// </summary>
        public static string SSEKMSKeyId = "X-Amz-Server-Side-Encryption-Aws-Kms-Key-Id";

        /// <summary>
        /// SSEKMSContext is the AWS SSE KMS Context.
        /// </summary>
        public static string SSEKMSContext = "X-Amz-Server-Side-Encryption-Context";
    }
}
