using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Exceptions
{
    public class InvalidObjectNameException : BaseException
    {
        private readonly string objectName;

        public InvalidObjectNameException(string objectName, string message) : base(message)
        {
            this.objectName = objectName;
        }

        public override string ToString() => $"{this.objectName}: {base.ToString()}";
    }
}
