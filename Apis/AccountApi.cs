

namespace shipcret_server_dotnet.Apis;


public static class AccountApis
{
	public static WebApplication MapAccountApis(this WebApplication app)
	{
		var root = app.MapGroup("/api/v1/account")
			.WithTags("account")
			.WithOpenApi();

		root.MapPost("/create", CreateUser);
	}

	public static async Task<IResult> CreateUser([FromBody] User user, [FromServices] IAccountService accountService)
	{
		var result = await accountService.CreateUser(user);

		return result;
	}
}