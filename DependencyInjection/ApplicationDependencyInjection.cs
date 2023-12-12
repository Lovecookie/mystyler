

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace shipcret_server_dotnet.DependencyInjection;

public static class  ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
    
}