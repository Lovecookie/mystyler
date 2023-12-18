

using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using shipcret_server_dotnet.Infrastructure.Commands;

public class CreateUserHandler(
	IUserBasicRepository userBasicRepository,
	ILogger<CreateUserHandler> logger ) : IRequestHandler<CreateUserCommand, UserBasicEntity>
{
	public async Task<UserBasicEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		//public string? UserName { get; init; }

		//public string? Email { get; init; }

		//public string? Password { get; init; }

		//public string? PictureUrl { get; init; }

		//public string? PictureName { get; init; }

		logger.LogInformation(request.UserName, request.Email, request.Password, request.PictureUrl, request.PictureName);


		var user = new UserBasicEntity
		{
			UserId = 1,
			UserName = request.UserName!,
			Email = request.Email!,
			Password = request.Password!,
			PictureUrl = request.PictureUrl!,
			PictureName = request.PictureName!
		};

		return await userBasicRepository.CreateAsync(user, cancellationToken);
	}
}