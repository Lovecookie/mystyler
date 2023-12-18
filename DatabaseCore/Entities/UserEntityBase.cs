namespace shipcret_server_dotnet.DatabaseCore.Entities;

public abstract record UserEntityBase
{
    public long UserId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }
}