using shipcret_server_dotnet.Account.Services;
using shipcret_server_dotnet.Infrastructure.Commands;
using shipcret_server_dotnet.Infrastructure.Features;
using shipcret_server_dotnet.Infrastructure.Requests;

namespace shipcret_server_dotnet.Account.Apis;


public static class AccountApis
{
    public static WebApplication MapAccountApis(this WebApplication app)
    {
        var apiUri = $"/api/{ShipcretVersion.GlobalVersionByLower}/account";

        var root = app.MapGroup($"{apiUri}")
            .WithTags("account")
            .WithOpenApi();

        root.MapPost("/create", CreateUser)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Create User")
            .WithDescription("\n POST /create");

        root.MapPost("/login", CreateUser)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Login User")
            .WithDescription("\n POST /login");

        return app;
    }

    public static async Task<IResult> CreateUser(
        [FromBody] CreateUserRequest createUserRequest,
        [AsParameters] AccountServices services
        )
    {
        var createUserCommand = services.Mapper.Map<CreateUserCommand>(createUserRequest);

        await services.Mediator.Send(createUserCommand);        

        return Results.Ok();
    }

    public static async Task<IResult> LoginUser(
        [FromBody] LoginUserRequest loginUserRequest,
        [AsParameters] AccountServices services)
    {
		//var result = await services.LoginUser(user);

		return await Task.FromResult(Results.Ok());
	}   
}