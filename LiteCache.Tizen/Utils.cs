using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Tizen.Security.SecureRepository;
using Tizen.System;
using System.Text;
using System.Diagnostics;

[assembly: InternalsVisibleTo("MonkeyCache.LiteDB")]
namespace LiteCache.Tizen
{
    internal static class Utils
    {
		public static string BasePath(string applicationPath)
		{
			if (string.IsNullOrWhiteSpace(applicationPath))
				throw new ArgumentException("You must set a ApplicationId for LiteCache by using Cotton.ApplicationId.");

			if (applicationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
				throw new ArgumentException("ApplicationId has invalid characters");

			return Path.Combine(applicationPath);
		}

		public static DateTime ReadExpiration(TimeSpan timeSpan)
		{
			try
			{
				return DateTime.UtcNow.Add(timeSpan);
			}
			catch
			{
				if (timeSpan.Milliseconds < 0)
					return DateTime.MinValue;

				return DateTime.MaxValue;
			}
		}
	}
}
