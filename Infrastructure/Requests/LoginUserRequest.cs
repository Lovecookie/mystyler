

namespace shipcret_server_dotnet.Infrastructure.Requests;

public record LoginUserRequest
{
	[Required]
	public string? Email { get; init; }

	[Required]
	public string? Password { get; init; }
}

