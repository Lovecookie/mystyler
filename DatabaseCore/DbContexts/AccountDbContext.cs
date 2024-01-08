
using shipcret_server_dotnet.Account.Extensions;
using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using System.Reflection;

namespace shipcret_server_dotnet.DatabaseCore.DbContexts;

public class AccountDbContext : DbContextAbstract
{
	public DbSet<UserBasic> UserBasics { get; set; }


	public AccountDbContext(DbContextOptions<AccountDbContext> options)
		: base(options)
	{
	}

	public AccountDbContext(DbContextOptions<AccountDbContext> options, IMediator mediator)
		: base(options, mediator)
	{	
	}

	public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
	{
		if(HasMediator)
		{
			await Mediator!.DispatchDomainEventAsync(this);
		}

		_ = base.SaveChangesAsync(cancellationToken);
		
		return true;		
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.HasDefaultSchema("account");
		//modelBuilder.UseIntegrationEventLogs();		
	}
}