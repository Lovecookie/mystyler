
using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using System.Reflection;

namespace shipcret_server_dotnet.DatabaseCore.DbContexts;

internal class AccountDbContext : DbContext, IUnitOfWork
{
	public DbSet<UserBasicEntity> UserBasicEntities { get; set; }

	private readonly IMediator? _mediator;
	private IDbContextTransaction? _transaction;

	public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
	{
	}

	public AccountDbContext(DbContextOptions<AccountDbContext> options, IMediator mediator) : base(options)
	{
		_mediator = mediator;
	}

	public IDbContextTransaction? Transaction => _transaction;
	public bool HasActiveTransaction => _transaction != null;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}