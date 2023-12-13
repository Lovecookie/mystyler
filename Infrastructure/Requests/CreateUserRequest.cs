

namespace shipcret_server_dotnet.Infrastructure.Requests;

public record CreateUserRequest
{
	[Required]
	public string? UserName { get; init; }

	[Required]
	public string? Email { get; init; }

	[Required]
	public string? Password { get; init; }

	[Required]
	public string? PictureUrl { get; init; }

	[Required]
	public string? PictureName { get; init; }

}

