

namespace shipcret_server_dotnet.Infrastructure.Commands;

public class HeatbeatCommand : IRequest<string>
{
	public string? HeartBeat { get; set; }
}