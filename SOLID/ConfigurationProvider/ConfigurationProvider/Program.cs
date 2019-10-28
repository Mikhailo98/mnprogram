using Epam.NetMentoring;
using SolidTask.ConfigurationProvider.ConfigurationProvider;

namespace SolidTask.ConfigurationProvider
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var configurationProvider = new TxtConfigurationProvider();
			var serviceSettings = configurationProvider.Get<ServiceSettings>();
			var ITserviceSettings = configurationProvider.Get<Epam.NetMentoring.IT.ServiceSettings>();
		}
	}
}