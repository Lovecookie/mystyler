﻿
using shipcret_server_dotnet.DatabaseCore.DbContexts;
using shipcret_server_dotnet.DatabaseCore.Entities;


namespace shipcret_server_dotnet.DatabaseCore.Repositories;

public interface IUserBasicRepository : IDefaultRepository<UserBasicEntity>
{
	Task<UserBasicEntity> CreateAsync(UserBasicEntity entity, CancellationToken cancellationToken);

}

internal class UserBasicRepository : IUserBasicRepository
{
	private readonly AccountDbContext _context;
	private readonly TimeProvider _timeProvider;

	public IUnitOfWork UnitOfWork => _context;
	

	public UserBasicRepository(AccountDbContext context, TimeProvider timeProvider)
	{ 
		_timeProvider = timeProvider;
		_context = context;
	}

	public async Task<UserBasicEntity> CreateAsync(UserBasicEntity entity, CancellationToken cancellationToken)
	{
		entity.DateCreated = _timeProvider.GetUtcNow().UtcDateTime;
		entity.DateModified = _timeProvider.GetUtcNow().UtcDateTime;

		var newEntity = _context.Add(entity).Entity;

		var result = await _context.SaveChangesAsync(cancellationToken);		

		return newEntity;
	}
}