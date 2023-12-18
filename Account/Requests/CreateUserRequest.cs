

namespace shipcret_server_dotnet.Account.Requests;


public record CreateUserRequest
{
    [Required, JsonPropertyName("userName")]
    public string? UserName { get; init; }

    [Required, JsonPropertyName("email")]
    public string? Email { get; init; }

    [Required, JsonPropertyName("pw")]
    public string? Password { get; init; }

    [Required, JsonPropertyName("picUrl")]
    public string? PictureUrl { get; init; }

    [Required, JsonPropertyName("picName")]
    public string? PictureName { get; init; }

}

