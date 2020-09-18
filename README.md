# AwsS3Authentication

An authenticator for use with [RestSharp](https://restsharp.dev/) to authenticate requests to the [AWS S3 API](https://docs.aws.amazon.com/AmazonS3/latest/dev/Introduction.html).

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
