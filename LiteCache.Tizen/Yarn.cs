using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiteCache.Tizen
{
    public class Yarn
    {
		/// <summary>
		/// Identifier of cache data
		/// </summary>
		[BsonId]
		public string Id { get; set; }

		/// <summary>
		/// Cached data
		/// </summary>
		public string Cached { get; set; }

		/// <summary>
		/// Expiration data of the object, stored in UTC
		/// </summary>
		public DateTime ExpirationTime { get; set; }
	}
}
