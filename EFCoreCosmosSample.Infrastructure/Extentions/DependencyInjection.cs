
using EFCoreCosmosSample.Core.Interfaces.Repositories;
using EFCoreCosmosSample.Infrastructure.Contexts;
using EFCoreCosmosSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace EFCoreCosmosSample.Infrastructure.Extentions
{
    public static class DependencyInjection
    {
		public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FamilyContext>(options =>
				options.UseCosmos(
					configuration["Cosmos:AccountEndpoint"],
					configuration["Cosmos:AccountKey"],
					configuration["Cosmos:DatabaseName"],
					cosmosOptions => {

                        cosmosOptions.HttpClientFactory(() =>
						{
							HttpMessageHandler httpMessageHandler = new HttpClientHandler()
							{
								ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
							};
							return new HttpClient(httpMessageHandler);
						});
						cosmosOptions.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Gateway);
					})
			);
			services
				.AddScoped<IFamilyRepository, FamilyRepository>();
		}
	}
}
