

using shipcret_server_dotnet.Infrastructure.Commands;
using shipcret_server_dotnet.Infrastructure.Entities;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserEntity>
{
	public async Task<UserEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		//public string? UserName { get; init; }

		//public string? Email { get; init; }

		//public string? Password { get; init; }

		//public string? PictureUrl { get; init; }

		//public string? PictureName { get; init; }

		var user = new UserEntity
		{
			UserId = 1,
			UserName = request.UserName!,
			Email = request.Email!,
			Password = request.Password!,
			PictureUrl = request.PictureUrl!,
			PictureName = request.PictureName!
		};

		return await Task.FromResult(user);
	}
}