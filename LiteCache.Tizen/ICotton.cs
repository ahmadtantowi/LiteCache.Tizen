using LiteCache.Tizen.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiteCache.Tizen
{
    public interface ICotton
    {
		bool Create(string key, string data, TimeSpan expireIn);
		bool Create<T>(string key, T data, TimeSpan expireIn);
		void Delete(params string[] key);
		void DeleteAll();
		void DeleteExpired();
		string Read(string key);
		T Read<T>(string key);
        IEnumerable<string> ReadKeys(CacheState state = CacheState.Active);
		bool IsExpired(string key);
		bool IsExists(string key);

		DateTime? ReadExpirationTime(string key);
	}
}
