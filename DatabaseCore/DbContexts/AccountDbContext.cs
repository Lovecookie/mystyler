
using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using System.Reflection;

namespace shipcret_server_dotnet.DatabaseCore.DbContexts;

public class AccountDbContext : DbContextAbstract
{
	public DbSet<UserBasicEntity> UserBasicEntities { get; set; }



	public AccountDbContext(DbContextOptions<AccountDbContext> options)
		: base(options)
	{
	}

	public AccountDbContext(DbContextOptions<AccountDbContext> options, IMediator mediator)
		: base(options, mediator)
	{	
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}