﻿
using shipcret_server_dotnet.DatabaseCore.DbContexts;
using shipcret_server_dotnet.DatabaseCore.Entities;


namespace shipcret_server_dotnet.DatabaseCore.Repositories;

public interface IUserBasicRepository : IDefaultRepository<UserBasic>
{
	Task<UserBasic> CreateAsync(UserBasic entity, CancellationToken cancellationToken);

}

internal class UserBasicRepository : IUserBasicRepository
{
	private readonly AccountDbContext _context;
	private readonly ILogger _logger;
	private readonly TimeProvider _timeProvider;

	public IUnitOfWork UnitOfWork => _context;
	

	public UserBasicRepository(AccountDbContext context, ILogger<UserBasicRepository> logger, TimeProvider timeProvider)
	{ 
		_timeProvider = timeProvider;
		_context = context;
		_logger = logger;
	}

	public async Task<UserBasic> CreateAsync(UserBasic entity, CancellationToken cancellationToken)
	{
		entity.DateCreated = _timeProvider.GetUtcNow().UtcDateTime;
		entity.DateModified = _timeProvider.GetUtcNow().UtcDateTime;

		try
		{
			var newEntity = _context.Add(entity).Entity;

			var result = await _context.SaveChangesAsync(cancellationToken);

			return newEntity;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex.Message);

			return new();
		}
	}
}