using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Exceptions
{
    public class InvalidObjectPrefixException : BaseException
    {
        private readonly string objectPrefix;

        public InvalidObjectPrefixException(string objectPrefix, string message) : base(message)
        {
            this.objectPrefix = objectPrefix;
        }

        public override string ToString() => $"{this.objectPrefix}: {base.ToString()}";
    }
}
