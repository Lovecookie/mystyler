using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using shipcret_server_dotnet.Infrastructure.Commands;

public class HeatbeatCommandHandler : IRequestHandler<HeatbeatCommand, string>
{
	private readonly IUserBasicRepository? _userBasicRepository;
	private readonly ILogger<HeatbeatCommandHandler>? _logger;

	public HeatbeatCommandHandler(IUserBasicRepository userBasicRepository, ILogger<HeatbeatCommandHandler> logger)
	{
		_userBasicRepository = userBasicRepository;
		_logger = logger;
	}

	public async Task<string> Handle(HeatbeatCommand request, CancellationToken cancellationToken)
	{
		return await Task<string>.FromResult(request.HeartBeat!);
	}
}