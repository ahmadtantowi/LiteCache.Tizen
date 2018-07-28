using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LiteCache.Tizen
{
	public class Cotton : ICotton
	{
		/// <summary>
		/// For store database file in device storage. Please use DependencyService.
		/// </summary>
		public static string CacheDirectory { get; set; } = string.Empty;

		/// <summary>
		/// Key for encrypt database file.
		/// </summary>
		public static string EncryptionKey { get; set; } = string.Empty;

		static readonly Lazy<string> _baseCacheDir = new Lazy<string>(() =>
		{
			return Path.Combine(Utils.BasePath(CacheDirectory), "LiteCache");
		});

		readonly LiteDatabase _db;

		static Cotton _instance = null;
		static LiteCollection<Yarn> _column;

		public static ICotton Current => _instance ?? (_instance = new Cotton());

		JsonSerializerSettings _jsonSettings;
		Cotton()
		{
			var directory = _baseCacheDir.Value;
			string path = Path.Combine(directory, "Cotton.db");
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			if (!string.IsNullOrWhiteSpace(EncryptionKey))
				path = $"Filename={path}; Password={EncryptionKey}";

			_db = new LiteDatabase(path);
			_column = _db.GetCollection<Yarn>();

			_jsonSettings = new JsonSerializerSettings
			{
				ObjectCreationHandling = ObjectCreationHandling.Replace,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				TypeNameHandling = TypeNameHandling.All,
			};
		}

		public bool Create(string key, string data, TimeSpan expireIn)
		{
			try
			{
				Yarn ent = new Yarn
				{
					Id = key,
					Cached = data,
					ExpirationTime = Utils.ReadExpiration(expireIn)
				};
				_column.Upsert(ent);

				return true;
			}
			catch (Exception exc)
			{
				Debug.Write($"{nameof(Create)}: {exc.Message}");
			}

			return false;
		}

		public bool Create<T>(string key, T data, TimeSpan expireIn)
		{
			try
			{
				Create(key, JsonConvert.SerializeObject(data, _jsonSettings), expireIn);

				return true;
			}
			catch (Exception exc)
			{
				Debug.WriteLine($"{nameof(Create)}: {exc.Message}");
			}

			return false;
		}

		public void Delete(params string[] key)
		{
			foreach (var k in key)
			{
				_column.Delete(k);
			}
		}

		public void DeleteAll()
		{
			_column.Delete(Query.All());
		}

		public void DeleteExpired()
		{
			_column.Delete(b => b.ExpirationTime.ToUniversalTime() < DateTime.UtcNow);
		}

		public bool IsExists(string key)
		{
			Yarn ent = _column.FindById(key);

			return ent != null;
		}

		public bool IsExpired(string key)
		{
			Yarn ent = _column.FindById(key);

			return ent == null ? true : (DateTime.UtcNow > ent.ExpirationTime.ToUniversalTime());
		}

		public string Read(string key)
		{
			try
			{
				Yarn ent = _column.FindById(key);

				return ent.Cached;
			}
			catch (Exception exc)
			{
				Debug.WriteLine($"{nameof(Read)}: {exc.Message}");
			}

			return string.Empty;
		}

		public T Read<T>(string key)
		{
			try
			{
				Yarn ent = _column.FindById(key);

				return JsonConvert.DeserializeObject<T>(ent.Cached, _jsonSettings);
			}
			catch (Exception exc)
			{
				Debug.WriteLine($"{nameof(Read)}: {exc.Message}");
			}

			return default(T);
		}

		public DateTime? ReadExpirationTime(string key)
		{
			Yarn ent = _column.FindById(key);

			return ent?.ExpirationTime;
		}
	}
}
