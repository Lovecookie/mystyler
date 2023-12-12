

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.AddConfigureApplicationBuilder();
builder.AddApplicationServices();

builder.Services.AddAuthorization();

var app = builder.Build();

//app.MapGroup("api/v1/account")
//	.MapAccountApi()
//	.RequireAuthorization();

////app.UseHttpsRedirection();
//app.UseAuthorization();

app.Run();
