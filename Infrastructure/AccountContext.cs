
using Microsoft.EntityFrameworkCore;

namespace shipcret_server_dotnet.Infrastructure;


public class AccountContext :DbContext
{
	public AccountContext(DbContextOptions<AccountContext> options, IConfiguration configuration) : base(options)
	{
	}

	//public DbSet<User> Users { get; set; } = default!;
	//public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
	//public DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = default!;
	//public DbSet<EmailConfirmationToken> EmailConfirmationToken { get; set; } = default!;

	//protected override void OnModelCreating(ModelBuilder modelBuilder)
	//{
	//	modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountContext).Assembly);
	//}
}