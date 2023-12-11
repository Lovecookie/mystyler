namespace shipcret_server_dotnet.Apis;

public class AccountServices(
	IMediator mediator,
	ILogger<AccountServices> logger)
{
	public IMediator Mediator { get; set; } = mediator;
	public ILogger<AccountServices> Logger { get; set; } = logger;

}
