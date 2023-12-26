using shipcret_server_dotnet.DatabaseCore.Repositories;

namespace shipcret_server_dotnet.DatabaseCore.Entities;



/// <summary>
///  UserBasicEntity
/// </summary>
public class UserBasicEntity : UserEntityBase, IAggregateRoot
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


/// <summary>
/// PatronageEntity
/// </summary>
public class PatronageEntity : UserEntityBase, IAggregateRoot
{
    [Required]
    public Int64 UserUid { get; set; }

    [Required]
    public Int64 FollowerCount { get; set; }

    [Required]
    public Int64 FollowingCount { get; set; }

    [Required]
    public Int64 StyleCount { get; set; }

    [Required]
    public Int64 FavoriteCount { get; set; }
}


public class RecognitionEntity : UserEntityBase, IAggregateRoot
{
    [Required]
    public Int64 FamousValue { get; set; }
}
