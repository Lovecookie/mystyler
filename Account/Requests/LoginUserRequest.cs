namespace shipcret_server_dotnet.Account.Requests;

public record LoginUserRequest
{
    [Required, JsonPropertyName("email")]
    public string? Email { get; init; }

    [Required, JsonPropertyName("pw")]
    public string? Password { get; init; }
}

