﻿using RucumaGate.Api.Abstractions.Interfaces.Injections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RucumaGate.Api.Db.Injections;

public class DatabaseModule : IDotnetModule
{
	public void Load(IServiceCollection services, IConfiguration configuration)
	{
		var nsp = typeof(DatabaseModule).Namespace!;
		var baseNamespace = nsp[..nsp.LastIndexOf(".")];
		services.Scan(scan => scan
			.FromAssemblyOf<DatabaseModule>()
			.AddClasses(classes => classes.InNamespaces(baseNamespace + ".Repositories"))
			.AsImplementedInterfaces()
			.WithSingletonLifetime()
		);
	}
}