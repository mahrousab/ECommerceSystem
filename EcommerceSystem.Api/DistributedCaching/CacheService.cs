using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecommerce.Api.DistributedCaching;

public class CacheService : ICacheService
{
	private readonly IDistributedCache _cache;

	public CacheService(IDistributedCache cache)
	{
		_cache = cache;
	}

	public async Task<T> GetAsync<T>(string key)
	{
		string data = await _cache.GetStringAsync(key);
		return (T)((data == null) ? ((object)default(T)) : ((object)JsonSerializer.Deserialize<T>(data)));
	}

	public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
	{
		await DistributedCacheExtensions.SetStringAsync(options: new DistributedCacheEntryOptions
		{
			AbsoluteExpirationRelativeToNow = expiration
		}, value: JsonSerializer.Serialize(value), cache: _cache, key: key);
	}
}
