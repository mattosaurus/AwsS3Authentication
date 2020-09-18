using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Exceptions
{
    public class InvalidBucketNameException : BaseException
    {
        private readonly string bucketName;

        public InvalidBucketNameException(string bucketName, string message) : base(message)
        {
            this.bucketName = bucketName;
        }

        public override string ToString() => $"{this.bucketName}: {base.ToString()}";
    }
}
