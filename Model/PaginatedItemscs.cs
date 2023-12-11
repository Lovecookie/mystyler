﻿
namespace shipcret_server_dotnet.Model;


public class PaginatedItems<TEntity>(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
{
	public int PageIndex { get; } = pageIndex;
	public int PageSize { get; } = pageSize;
	public long Count { get; } = count;
	public IEnumerable<TEntity> Data { get; } = data;
}