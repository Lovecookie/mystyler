
namespace shipcret_server_dotnet.ServiceDefaults;

public static class AuthenticationExtentions
{
	public static IServiceCollection AddDefaultAuthentication(this IHostApplicationBuilder builder)
	{
		var services = builder.Services;
		var configuration = builder.Configuration;

		services.AddAuthorization();

		var identitySection = configuration.GetSection("Identity");
        if (identitySection.Exists())
        {
			return services;
        }

		return services;
    }
}	