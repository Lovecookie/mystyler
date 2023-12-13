

namespace shipcret_server_dotnet.Infrastructure.Entities;

public abstract record UserEntityBase
{	
	public Int64 UserId { get; set; }

	public DateTime DateCreated { get; init; }

	public DateTime DateModified { get; set; }
}