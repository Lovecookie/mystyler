using shipcret_server_dotnet.DatabaseCore.Repositories;
using shipcret_server_dotnet.Infrastructure.Constants;

namespace shipcret_server_dotnet.DatabaseCore.Entities;



/// <summary>
///  UserBasic
/// </summary>
public class UserBasic : UserEntityBase, IAggregateRoot
{
	[MaxLength(ConstantLength.UserId)]
    public string UserId { get; set; } = ""; 

    [MaxLength(ConstantLength.EMail)]
    public string Email { get; set; } = "";

    [MaxLength(ConstantLength.Password)]
    public string Password { get; set; } = "";

    [MaxLength(ConstantLength.PictureUrl)]
    public string PictureUrl { get; set; } = "";
}


/// <summary>
/// UserPatronage
/// </summary>
public class UserPatronage : UserEntityBase, IAggregateRoot
{
    [Required]
    public Int64 FollowerCount { get; set; }

    [Required]
    public Int64 FollowingCount { get; set; }

    [Required]
    public Int64 StyleCount { get; set; }

    [Required]
    public Int64 FavoriteCount { get; set; }
}


/// <summary>
/// UserRecognition
/// </summary>
public class UserRecognition : UserEntityBase, IAggregateRoot
{
    [Required]
    public Int64 FamousValue { get; set; }
}
