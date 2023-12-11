

using shipcret_server_dotnet.Apis;

public static class AccountApi
{
	public static RouteGroupBuilder MapOrderApi(this RouteGroupBuilder builder)
	{
		builder.MapGet("/create", CreateUserAsync);

		return builder;
	}

	public static async Task<Results<Ok, BadRequest<string>, ProblemHttpResult>> CreateUserAsync(
		[FromHeader(Name = "x-requestid")] Guid requestId,
		CreateUserCommand command,
		[AsParameters] AccountServices services )
	{
		if(requestId == Guid.Empty)
		{
			return TypedResults.BadRequest("Empty GUID.");
		}

		var requestCreateUser = new IdentifiedCommand<CreateUserCommand, bool>(command, requestId);

		services.Logger.LogInformation(
			"Send command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
			requestCreateUser.GetGenericTypeName(),
			nameof(requestCreateUser.Command.UserName),
			requestCreateUser.Command.UserName,
			requestCreateUser);

		var commandResult = await services.Mediator.Send(requestCreateUser);

		if (!commandResult)
		{
			return TypedResults.Problem(detail: "create user is failed to process.", statusCode: 500);
		}

		return TypedResults.Ok();
	}
}