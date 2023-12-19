

using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using shipcret_server_dotnet.Infrastructure.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserBasicEntity>
{
	private readonly IUserBasicRepository? _userBasicRepository;
	private readonly ILogger<CreateUserHandler>? _logger;

	public CreateUserHandler(IUserBasicRepository userBasicRepository, ILogger<CreateUserHandler> logger)
	{
		_userBasicRepository = userBasicRepository;
		_logger = logger;
	}

	public async Task<UserBasicEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		//public string? UserName { get; init; }

		//public string? Email { get; init; }

		//public string? Password { get; init; }

		//public string? PictureUrl { get; init; }

		//public string? PictureName { get; init; }

		_logger!.LogInformation(request.UserName, request.Email, request.Password, request.PictureUrl, request.PictureName);


		var user = new UserBasicEntity
		{
			UserId = 1,
			UserName = request.UserName!,
			Email = request.Email!,
			Password = request.Password!,
			PictureUrl = request.PictureUrl!,
			PictureName = request.PictureName!
		};

		return await _userBasicRepository!.CreateAsync(user, cancellationToken);
	}
}