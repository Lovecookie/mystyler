﻿

using AutoMapper;
using shipcret_server_dotnet.DatabaseCore.Entities;
using shipcret_server_dotnet.DatabaseCore.Repositories;
using shipcret_server_dotnet.Infrastructure.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserBasic>
{	
	private readonly IUserBasicRepository _userBasicRepository;
	private readonly IMapper _mapper;

	public CreateUserHandler(IUserBasicRepository userBasicRepository, IMapper mapper)
	{
		_userBasicRepository = userBasicRepository;
		_mapper = mapper;
	}

	public async Task<UserBasic> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var userEntity = _mapper.Map<UserBasic>(request);

		return await _userBasicRepository.CreateAsync(userEntity, cancellationToken);
	}
}