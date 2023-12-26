using shipcret_server_dotnet.Account.Requests;
using shipcret_server_dotnet.Account.Services;
using shipcret_server_dotnet.Infrastructure.Commands;
using shipcret_server_dotnet.Infrastructure.Features;


namespace shipcret_server_dotnet.Account.Apis;


public static class AccountApis
{
    public static WebApplication MapAccountApis(this WebApplication app)
    {
        var apiUri = $"/api/{ShipcretVersion.GlobalVersionByLower}/account";

        var root = app.MapGroup($"{apiUri}")
            .WithGroupName(ShipcretVersion.GlobalVersionByLower)
            .WithTags("account")
            .WithOpenApi();

        root.MapGet("/heartbeat", Heartbeat)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Heartbeat")
            .WithDescription("\n GET /heartbeat");


		root.MapPost("/create", CreateUser)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Create User")
            .WithDescription("\n POST /create");

        root.MapPost("/login", LoginUser)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Login User")
            .WithDescription("\n POST /login");

        return app;
    }

    public static async Task<IResult> Heartbeat(
        [AsParameters] AccountServices services )
    {
        var heartbeatCommand = new HeartbeatCommand
        {
            HeartBeat = "1"
        };

        var heatbeat = await services.Mediator.Send(heartbeatCommand);

        return Results.Ok(heatbeat!);
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