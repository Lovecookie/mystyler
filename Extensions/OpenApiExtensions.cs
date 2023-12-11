using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace shipcret_server_dotnet.ServiceDefaults;

public static partial class Extenstions
{
	public static IHostApplicationBuilder AddDefaultOpenApi(this IHostApplicationBuilder builder)
	{
		var services = builder.Services;
		var configuration = builder.Configuration;

		var openApi = configuration.GetSection("OpenApi");

		if(!openApi.Exists())
		{
			return builder;
		}	

		services.AddEndpointsApiExplorer();

		services.AddSwaggerGen(options =>
		{
			var document = openApi.GetRequiredSection("Document");
			var version = document.GetValue<string>("Version") ?? "v1";

			options.SwaggerDoc(version, new OpenApiInfo
			{
				Title = document.GetValue<string>("Title"),
				Version = version,
				Description = document.GetValue<string>("Description"),
			});

			var identifySection = document.GetSection("Identify");
			if(!identifySection.Exists())
			{
				return;
			}

			var identifyUrlExternal = identifySection.GetValue<string>("Url");
			var scopes = identifySection.GetSection("Scopes").GetChildren().ToDictionary(p => p.Key, p => p.Value);

			options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
			{
				Type = SecuritySchemeType.OAuth2,
				Flows = new OpenApiOAuthFlows
				{
					Implicit = new OpenApiOAuthFlow
					{
						AuthorizationUrl = new Uri($"{identifyUrlExternal}/connect/authorize"),
						TokenUrl = new Uri($"{identifyUrlExternal}/connect/token"),
						Scopes = scopes,
					},
				},
			});

			options.OperationFilter<AuthorizeCheckOperationFilter>([scopes.Keys.ToArray()]);
		});

		return builder;
	}

	private sealed class AuthorizeCheckOperationFilter(string[] scopes) : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			var metadata = context.ApiDescription.ActionDescriptor.EndpointMetadata;

			if (!metadata.OfType<IAuthorizeData>().Any())
			{
				return;
			}

			operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
			operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

			var oAuthScheme = new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
			};

			operation.Security = new List<OpenApiSecurityRequirement>
			{
				new()
				{
					[ oAuthScheme ] = scopes
				}
			};
		}
	}
}