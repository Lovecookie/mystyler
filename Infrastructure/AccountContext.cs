

namespace shipcret_server_dotnet.Infrastructure.DbContexts;


//public class AccountContext : DbContext
//{
//	public DbSet<User> Users { get; set; }

//	private readonly IMediator _mediator;
//	private IDbContextTransaction? _transaction;


//	public bool HasActiveTransaction => _transaction != null;
//	public IDbContextTransaction? GetTransaction() => _transaction;	
	

//	public AccountContext(DbContextOptions<AccountContext> options, IMediator mediator ) : base(options)
//	{
//		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

//		System.Diagnostics.Debug.WriteLine("AccountContext::ctor ->" + this.GetHashCode());
//	}

//	protected override void OnModelCreating(ModelBuilder builder)
//	{
//		base.OnModelCreating(builder);
//	}

//}