using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwsS3Authentication.Helpers
{
    public static class AwsS3RestServiceCollectionExtensions
    {
        public static IServiceCollection AddAwsRestClient(this IServiceCollection collection, string accessKey, string secretKey)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            RestClient restClient = new RestClient();
            restClient.Authenticator = new V4Authenticator(true, accessKey, secretKey);

            return collection.AddSingleton<IRestClient>(restClient);
        }
    }
}
