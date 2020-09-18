# AwsS3Authentication

An authenticator for use with [RestSharp](https://restsharp.dev/) to authenticate requests to the [AWS S3 API](https://docs.aws.amazon.com/AmazonS3/latest/dev/Introduction.html), this is based on the [MinIO authenticator](https://github.com/poornas/minio-csharp-sdk/blob/2965a6f6bfae260661a39317fd0d62d55c664006/Minio.Api/V4Authenticator.cs).

Can be used to set the authenticator directly or via Dependency Injection as below.

```
private IServiceCollection ConfigureServices(IServiceCollection services)
{
	services
		.AddLogging(loggingBuilder =>
			loggingBuilder.AddSerilog(dispose: true)
		);

	services.AddAwsRestClient("<MY ACCESS KEY>", "<MY SECRET KEY>");

	return services;
}
```
