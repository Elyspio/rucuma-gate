using RucumaGate.Api.Abstractions.Interfaces.Injections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RucumaGate.Api.Adapters.AuthenticationApi;
using RucumaGate.Api.Adapters.Configs;

namespace RucumaGate.Api.Adapters.Injections;

public class AdapterModule : IDotnetModule
{
	public void Load(IServiceCollection services, IConfiguration configuration)
	{
		var conf = new EndpointConfig();
		configuration.GetSection(EndpointConfig.Section).Bind(conf);

		services.AddHttpClient<IAuthenticationClient, AuthenticationClient>(client => { client.BaseAddress = new(conf.Authentication); });
	}
}