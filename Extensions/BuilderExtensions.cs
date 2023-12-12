


using Serilog;
using System.Globalization;

namespace shipcret_server_dotnet.Extenstions;

public static class DefaultExtentions
{
	public static WebApplication WebApplication(this WebApplication app)
	{
		app.UseSerilogRequestLogging();

		app.UseHsts();

		app.UseHttpsRedirection();

		var textInfo = CultureInfo.CurrentCulture.TextInfo;

		app.UseSwagger();
		app.UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("swagger/v1/swagger.json", $"Shipcret API - {textInfo.ToTitleCase(app.Environment.EnvironmentName)} - V1");
		});

		app.Mapp
	}
}