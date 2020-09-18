# AwsS3Authentication

An authenticator for use with RestSharp to authenticate requests to the AWS S3 API.

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
