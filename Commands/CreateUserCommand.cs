

namespace shipcret_server_dotnet.Commands;

[DataContract]
public class CreateUserCommand : IRequest<bool>
{
	[DataMember]
	public required string UserName { get; set; }
}
