using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SolidTask.ConfigurationProvider.Helpers
{
	public static class TxtLocalStorage
	{
		private const string TestSearchPattern = "Test*.txt";
		private const string DevSearchPattern = "default.txt";

		private static string WorkingDirectoryRoot => Directory.GetParent(path: 
            Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName;


		public static IEnumerable<FileInfo> GetConfigFiles()
		{
			var directoryInfo = new DirectoryInfo(WorkingDirectoryRoot);

            yield return directoryInfo.EnumerateFiles(DevSearchPattern, SearchOption.AllDirectories).FirstOrDefault()
			              ?? throw new FileNotFoundException("default.txt is obligatory!");

			var tests = directoryInfo.EnumerateFiles(TestSearchPattern, SearchOption.AllDirectories)
				.OrderByDescending(o => o.Length);

			foreach (var files in tests)
                yield return files;
		}
	}
}