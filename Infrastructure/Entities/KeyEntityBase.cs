

namespace shipcret_server_dotnet.Infrastructure.Entities;

internal abstract record KeyEntityBase
{
	public Int64 UniqueKey { get; set; }

	public DateTime DateCreated { get; init; }

	public DateTime DateModified { get; set; }
}