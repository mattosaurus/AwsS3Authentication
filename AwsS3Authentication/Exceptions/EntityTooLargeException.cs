using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Exceptions
{
    public class EntityTooLargeException : BaseException
    {
        public EntityTooLargeException(string message) : base(message)
        {
        }
    }
}
