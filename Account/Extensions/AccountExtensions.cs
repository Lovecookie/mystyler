namespace shipcret_server_dotnet.Account.Extensions;

public static class AccountExtensions
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