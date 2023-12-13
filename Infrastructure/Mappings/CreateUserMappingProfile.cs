
using AutoMapper;
using shipcret_server_dotnet.Infrastructure.Commands;
using shipcret_server_dotnet.Infrastructure.Entities;
using shipcret_server_dotnet.Infrastructure.Requests;

public class CreateUserMappingProfile : Profile
{
	public CreateUserMappingProfile()
	{
		CreateMap<CreateUserRequest, CreateUserCommand>();

		CreateMap<CreateUserCommand, UserEntity>();
	}
}