
using shipcret_server_dotnet.DatabaseCore.Repositories;



namespace shipcret_server_dotnet.DatabaseCore.DbContexts;

public abstract class DbContextAbstract : DbContext, IUnitOfWork
{
	protected readonly IMediator? _mediator;
	protected readonly IDbContextTransaction? _transaction;

	public DbContextAbstract(DbContextOptions options) : base(options)
	{
	}

	public DbContextAbstract(DbContextOptions options, IMediator? mediator) : base(options)
	{
	}

	public bool HasTransaction => _transaction != null;
	public IDbContextTransaction? Transaction => _transaction;


	protected bool _HasMediator => _mediator != null;
	protected IMediator? _Mediator => _mediator;	
}