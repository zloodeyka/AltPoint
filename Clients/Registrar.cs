using Clients.Converters;
using Clients.Managers;
using Clients.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Clients
{
	public static class Registrar
	{
		public static void RegisterClients(this IServiceCollection services)
		{
			services.AddScoped<IClientConverter, ClientConverter>();
			services.AddScoped<IClientValidator, ClientValidator>();
			services.AddScoped<IClientsManager, ClientsManager>();
		}
	}
}
