
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;


namespace shipcret_server_dotnet.ServiceDefaults;

public static partial class Extentions
{
	public static IHostApplicationBuilder AddServiceDefaults(this IHostApplicationBuilder builder)
	{
		builder.AddBasicServiceDefaults();

		builder.Services.AddServiceDiscovery();

		builder.Services.ConfigureHttpClientDefaults(http =>
		{
			http.AddStandardResilienceHandler();

			http.UseServiceDiscovery();
		});

		return builder;
	}

	public static IHostApplicationBuilder AddBasicServiceDefaults(this IHostApplicationBuilder builder)
	{
		builder.AddDefaultHealthChecks();
		builder.ConfigureOpenTelemetry();

		return builder;
	}

	public static IHostApplicationBuilder AddDefaultHealthChecks(this IHostApplicationBuilder builder)
	{
		builder.Services.AddHealthChecks()
			.AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

		return builder;
	}

	public static IHostApplicationBuilder ConfigureOpenTelemetry(this IHostApplicationBuilder builder)
	{
		builder.Logging.AddOpenTelemetry(o =>
		{
			o.IncludeFormattedMessage = true;
			o.IncludeScopes = true;
		});

		builder.Services.AddOpenTelemetry()
			.WithMetrics(metrics =>
			{
				metrics.AddRuntimeInstrumentation()
						.AddBuiltInMeters();
			})
			.WithTracing(tracing =>
			{
				if (builder.Environment.IsDevelopment())
				{
					tracing.SetSampler(new AlwaysOnSampler());
				}
			});

		builder.AddOpenTelemetryExporters();

		return builder;
	}


	private static MeterProviderBuilder AddBuiltInMeters(this MeterProviderBuilder meterProviderBuilder) =>
	meterProviderBuilder.AddMeter(
		"Microsoft.AspNetCore.Hosting",
		"Microsoft.AspNetCore.Server.Kestrel",
		"System.Net.Http");

	private static IHostApplicationBuilder AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
	{
		var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

		if(useOtlpExporter)
		{
			builder.Services.Configure<OpenTelemetryLoggerOptions>(logging => logging.AddOtlpExporter());
			builder.Services.ConfigureOpenTelemetryMeterProvider(metrics => metrics.AddOtlpExporter());
			builder.Services.ConfigureOpenTelemetryTracerProvider(tracing => tracing.AddOtlpExporter());
		}

		builder.Services.AddOpenTelemetry()
			.WithMetrics(metrics =>
			{
			});

		return builder;
	}
}