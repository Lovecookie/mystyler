

using shipcret_server_dotnet.DatabaseCore.Entities;

namespace shipcret_server_dotnet.Infrastructure.Commands;


public class CreateUserCommand : IRequest<UserBasicEntity>
{
	public string? UserName { get; init; }

	public string? Email { get; init; }

	public string? Password { get; init; }

	public string? PictureUrl { get; init; }

	public string? PictureName { get; init; }
}