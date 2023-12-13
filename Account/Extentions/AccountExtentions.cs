namespace shipcret_server_dotnet.Account.Extentions;

public static class AccountExtentions
{

    public static WebApplicationBuilder AddAccountApplicationServices(this WebApplicationBuilder builder)
    {
		var services = builder.Services;

		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssemblyContaining(typeof(Program));
		});

		return builder;
	}

}