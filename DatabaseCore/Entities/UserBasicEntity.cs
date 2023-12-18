namespace shipcret_server_dotnet.DatabaseCore.Entities;

public record UserBasicEntity : UserEntityBase
{
    [Required]
    public string UserName { get; set; } = default!;

    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;

    [Required]
    public string PictureUrl { get; set; } = default!;

    [Required]
    public string PictureName { get; set; } = default!;
}