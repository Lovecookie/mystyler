namespace shipcret_server_dotnet.Account.Requests;

public record LoginUserRequest
{
    [Required]
    public string? Email { get; init; }

    [Required]
    public string? Password { get; init; }
}

