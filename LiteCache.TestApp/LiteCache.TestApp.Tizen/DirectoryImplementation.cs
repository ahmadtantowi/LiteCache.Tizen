using LiteCache.TestApp.Tizen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.Applications;

[assembly: Xamarin.Forms.Dependency(typeof(DirectoryImplementation))]
namespace LiteCache.TestApp.Tizen
{
	public class DirectoryImplementation : IDirectory
	{
		public string ApplicationPath()
		{
			return Application.Current.DirectoryInfo.Data;
		}
	}
}
