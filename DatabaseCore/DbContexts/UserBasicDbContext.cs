
using shipcret_server_dotnet.DatabaseCore.Entities;
using System.Reflection;

namespace shipcret_server_dotnet.DatabaseCore.DbContexts;

internal class UserBasicDbContext(DbContextOptions<UserBasicDbContext> options) : DbContext(options)
{
	public DbSet<UserBasicEntity> UserBasicEntities { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}


}