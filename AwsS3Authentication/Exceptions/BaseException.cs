using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Exceptions
{
    [Serializable]
    public class BaseException : Exception
    {
        private static string GetMessage(string message, IRestResponse serverResponse)
        {
            if (serverResponse == null && string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            if (serverResponse == null)
                return $"MinIO API responded with message={message}";

            if (message == null)
                return $"MinIO API responded with status code={serverResponse.StatusCode}, response={serverResponse.ErrorMessage}, content={serverResponse.Content}";

            return $"MinIO API responded with message={message}. Status code={serverResponse.StatusCode}, response={serverResponse.ErrorMessage}, content={serverResponse.Content}";
        }

        public BaseException(IRestResponse serverResponse)
            : this(null, serverResponse)
        {
        }

        public BaseException(string message)
            : this(message, null)
        {
        }

        public BaseException(string message, IRestResponse serverResponse)
            : base(GetMessage(message, serverResponse))
        {
            this.ServerMessage = message;
            this.ServerResponse = serverResponse;

        }

        public string ServerMessage { get; }

        public IRestResponse ServerResponse { get; }

        public ErrorResponse Response { get; internal set; }

        public string XmlError { get; internal set; }
    }
}
